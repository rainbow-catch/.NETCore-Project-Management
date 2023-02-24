using DataRoom.Models;
using DataRoom.Service.Impl;
using DataRoom.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // For .NET 5
            services.AddIdentity<ApplicationUser, IdentityRole>(options => 
            {
                // Override the default PasswordOptions rules while in development environment
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                // Confrim email or else, we dont allow user to login even
                // after the user registration is completed
                options.SignIn.RequireConfirmedEmail = true;

                // Account lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders(); // Register token provider

            // Set the token validity to 10 hours. So this means the user can change the password in under 10 hours time.
            services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(10));

            services.AddControllers(options => options.EnableEndpointRouting = false);

            // If someone like HomeController reqeusts IEmployeeRepository service, then create instance of MockEmployeeRepository class and then injects that instance
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
            services.AddScoped<IEmailHelper, EmailHelper>();
            // services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();

            // We use SqlServer as a database providers
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDbConnection")));

            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                // Global authorization that only sign in user can access to controller and its action
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            // Claims & roles
            services.AddAuthorization(options =>
            {
                // Claims
                // 1. Create a claims policy
                // 2. Use the policy on a controller or a controller action
                // To add multiple claims to a given policy, chain RequireClaim() method
                // To satisfy this policy requirements, the loggedin user must have both the claims i.e create & delete roles claims
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role")
                                    .RequireClaim("Create Role") // Adds more claims here
                    );

                options.AddPolicy("EditRolePolicy", // For Edit policy to be succeeded, the claim value must be true
                    policy => policy.RequireClaim("Edit Role", "true") // Adds more claims here

                    );

                // Roles
                // This is used in Administration controller 
                options.AddPolicy("AdminRolePolicy",
                    policy => policy.RequireRole("Admin") // Adds more roles here via chain method
                    );

            });

            // Change default AccessDenied route from Account controller to Administration controller
            services.ConfigureApplicationCookie(options => 
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });

            // Google authentication by installing Microsoft.AspNetCore.Authentication.Google nuget package
            // https://www.roundthecode.com/dotnet/how-to-add-google-authentication-to-a-asp-net-core-application
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/account/google-login"; // Must be lowercase
            })
            .AddGoogle(options =>
            {
                options.ClientId = "280608216916-jo6v1bos56d2j2hk63c58uiaalkilu81.apps.googleusercontent.com";
                options.ClientSecret = "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";

                //options.ClientId = _config["Authentication:Google:ClientId"];
                //options.ClientSecret = _config["Authentication:Google:ClientSecret"];

            })
            .AddFacebook(options =>
            {
                options.AppId = "747857913107329";
                options.AppSecret = "83615f5b8c08b9bedb59488191587904";

            });

            // Since we will be calling Web API from JavaScript so we will have to deal with “same-origin policy” problem
            // for file upload progress bar
            //services.AddCors();
            //services.AddControllersWithViews();

            // To completely remove the file upload limit set this property to null
            // https://www.webdavsystem.com/server/documentation/large_files_iis_asp_net/
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = null;
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = null;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // If development then we use development exception page middleware to display exception error page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The placeholder {0}, in "/Error/{0}" will automatically receive the http status code
                // Calls ErrorController action method by passing error statusCode 
                // app.UseStatusCodePagesWithReExecute("/Error/{0}");

                // For a non-development environment, add the Exception Handling Middleware to the request processing pipeline
                // using UseExceptionHandler() method
                // Redirect to custom error view in the Shared folder
                app.UseExceptionHandler("/Error");
            }
            
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // Shows UseCors with CorsPolicyBuilder
            // File upload with progress bar
            //app.UseCors(builder =>
            //{
            //    builder
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //});

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});
        }
    }
}
