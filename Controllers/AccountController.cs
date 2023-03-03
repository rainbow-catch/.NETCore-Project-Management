using DataRoom.Models;
using DataRoom.Service.Interface;
using DataRoom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataRoom.Utilities;
using System.Net.Mail;

namespace DataRoom.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
       // private readonly RoleManager<IdentityRole> roleManager;

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IEmailService _emailService = null;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger,
            IWebHostEnvironment webHostEnvironment,
            IEmailService emailService, AppDbContext context
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _emailService = emailService;
            _context = context;

            //userManager.UserValidators = new UserValidator(userManager) { AllowOnlyAlphanumericUserNames = false };
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Upon successful authentication, Google redirects the user back
            // to our application and the following ExternalLoginCallback action is executed
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            
            return new ChallengeResult(provider, properties);
        }

        /// <summary>
        /// how to confirm the email received from external login providers such as Google, Facebook etc.
        /// When we use external providers like Google or Facebook to login, we receive the user email from these external login provider. 
        /// We then use this email to create a local user account.
        /// Upon creating a local user account, send email confirmation link. If the email address is not confirmed, 
        /// do not allow the user to login and display the error - Email not confirmed yet.
        /// On the other hand, if the email address is confirmed, create an external login (AspNetUserLogins) and sign-in the user.
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <param name="remoteError"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty,
                    $"Error from external provider: {remoteError}");

                return View("Login", loginViewModel);
            }

            // Get the login information about the user from the external login provider
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");

                return View("Login", loginViewModel);
            }

            // Get the email address from external login provider (Google, Facebook etc)
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            ApplicationUser user = null;

            if (email != null)
            {
                // Find the user
                user = await userManager.FindByEmailAsync(email);

                // If email is not confirmed, display login view with validation error
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View("Login", loginViewModel);
                }
            }

            // If the user already has a login (i.e if there is a record in AspNetUserLogins
            // table) then sign-in the user with this external login provider
            var signInResult = await signInManager.ExternalLoginSignInAsync(
                                        info.LoginProvider, info.ProviderKey,
                                        isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            // If there is no record in AspNetUserLogins table, the user may not have
            // a local account thus create one then
            {
                if (email != null)
                {
                    // If the external user (Google or Facebook) is not exist, then creates a new user without password
                    // If the user exists then we dont have to end up creating a new user
                    // This is the scenario where a single email address is used to sign-in to
                    // Google and Facebook. So there is relationship between AspNetUsers and AspNetUserLogins tables
                    if (user == null)
                    {
                        MailAddress address = new MailAddress(email);
                        string userName = address.User;

                        // Creates an instance of user that represents the external user along with its details
                        user = new ApplicationUser
                        {
                            Name = info.Principal.FindFirstValue(ClaimTypes.Name),

                            StreetAddress = info.Principal.FindFirstValue(ClaimTypes.StreetAddress),
                            // City = info.Principal.FindFirstValue(ClaimTypes.Country),
                            Country = info.Principal.FindFirstValue(ClaimTypes.Country),
                            PhoneNumber = info.Principal.FindFirstValue(ClaimTypes.MobilePhone),

                            UserName = userName,
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        // Creates a local user in AspNetUsers table
                        await userManager.CreateAsync(user);

                        // Once the user is created in the system, add the user to Bibders role by default
                        await userManager.AddToRoleAsync(user, "Bidders");

                        // After a local user account is created, generate email confirmation link
                        // And send the user an email either gmail or facebook email addresses
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                        var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                        //logger.Log(LogLevel.Warning, confirmationLink);

                        string subjectLine = "Confirm Email";

                        // If we could successfully send mail
                        if (_emailService.SendEmail(email, subjectLine, confirmationLink))
                        {
                            // Creates a login (i.e insert a row for the user in AspNetUserLogins table)
                            // and links to AspNetUsers table. One UserId in AspNetusers table links to
                            // two logins i.e Google & Facebook in AspNetUserLogins table
                            await userManager.AddLoginAsync(user, info);
                            await signInManager.SignInAsync(user, isPersistent: false);

                            ViewBag.SuccessTitle = "Registration successful";
                            ViewBag.SuccessMessage = "Before you can Login, please confirm your " +
                                "email, by clicking on the confirmation link we have emailed you";
                            return View("Success");
                        }
                        else
                        {
                            // Log email failed
                            logger.Log(LogLevel.Warning, "Send mail failed");

                            ViewBag.ErrorTitle = "Send mail failed";
                            ViewBag.ErrorMessage = "Can't send mail. Please try again later";
                            return View("Error");
                        }
                    }

                    return LocalRedirect(returnUrl);
                }

                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on appsrequest@mof.gov.tl";

                return View("Error");
            }
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                await signInManager.RefreshSignInAsync(user);
                
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await userManager.FindByEmailAsync(model.Email);
                
                // If the user is found AND Email is confirmed
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    // Generate the reset password token
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);

                    // Log the password reset link
                    //logger.Log(LogLevel.Warning, passwordResetLink);
                    string subjectLine = "Reset Password";

                    // If we could successfully send mail
                    if (_emailService.SendEmail(user.Email, subjectLine, passwordResetLink))
                    {
                        return View("ForgotPasswordConfirmation");
                    }
                    else
                    {
                        // Log email failed
                        logger.Log(LogLevel.Warning, "Send mail failed");

                        ViewBag.ErrorTitle = "Send mail failed";
                        ViewBag.ErrorMessage = "Can't send mail. Please try again later";
                        return View("Error");
                    }

                    // Send the user to Forgot Password Confirmation view
                    //return View("ForgotPasswordConfirmation");
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }

                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return View("ResetPasswordConfirmation");
            }

            // Display validation errors if model state is not valid
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var termsTxtPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "terms.txt");
            var terms = System.IO.File.ReadAllText(termsTxtPath);
            ViewBag.termsAndCondition = terms.Replace("\r", "&nbsp;").Replace("\n", "<br/>");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                MailAddress address = new MailAddress(model.Email);
                
                var user = new ApplicationUser
                {
                    StreetAddress=model.StreetAddress,
                    City=model.City,
                    Country=model.Country,

                    Name = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Name,
                    CompanyName = model.CompanyName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Commented out by Sothun because otherwise a user can claim as project owner
                    // During the registration process, the system should automatically places the user in Bidder role
                    // Now it is Admin's job to decide which which user is the project owner. We have this functionality already existed
                    // by login as admin and add the user to the owner role
                    //if (model.IsOwner)
                    //{
                    await userManager.AddToRoleAsync(user, "Bidders");
                    //}

                    // Add registered use to active projects
                    var activeProjects = _context.Project.Where(p => p.IsActive);
                    foreach(var project in activeProjects)
                    {
                        _context.BidderProjects.Add(new BidderProject
                        {
                            BidderId = user.Id,
                            ProjectId = project.Id
                        });
                        System.IO.Directory.CreateDirectory("Upload/" + project.Name + "/" + user.UserName);
                    }

                    // Once a user has been successfully created in the system
                    // we need to send the user an email and request the user to confirm it
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId=user.Id, token=token }, Request.Scheme);
                    
                    // If the user is signed in and in the Admin role, then it is
                    // the Admin user that is creating a new user. So redirect the
                    // Admin user to ListRoles action
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admins"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

                    if(_emailService.SendEmailConfirmationTemplate(model.Email, confirmationLink))
                    {
                        ViewBag.ErrorTitle = "Registration was successful";
                        ViewBag.ErrorMessage = "Before you can login, please confirm your email by clicking on confirmation link we have emailed you.";
                        return View("Error");
                    }
                    else
                    {
                        // Log email failed
                        logger.Log(LogLevel.Warning, "Send mail failed");

                        ViewBag.ErrorTitle = "Send mail failed";
                        ViewBag.ErrorMessage = "Can't send mail. Please try again later";
                        return View("Error");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        /// <summary>
        /// This method gets called by clicking the link in the mail content
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            
            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                // Populate a list of external login providers
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            // Returns the list of all configured external identity providers like (Google, Facebook etc)
            model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // Check whether the email provided is existed
                var user = await userManager.FindByEmailAsync(model.Email);

                // 1. Check whether the user has actually confirmed via email
                // 2. And also check whether user provided username & password conbinations correct
                if (user != null && !user.EmailConfirmed && (await userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }

                // The last boolean parameter lockoutOnFailure indicates if the account
                // should be locked on failed logon attempt. On every failed logon
                // attempt AccessFailedCount column value in AspNetUsers table is
                // incremented by 1. When the AccessFailedCount reaches the configured
                // MaxFailedAccessAttempts which in our case is 5, the account will be
                // locked and LockoutEnd column is populated. After the account is
                // lockedout, even if we provide the correct username and password,
                // PasswordSignInAsync() method returns Lockedout result and the login
                // will not be allowed for the duration the account is locked.
                var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                // If account is lockedout send the use to AccountLocked view
                if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }
    }
}
