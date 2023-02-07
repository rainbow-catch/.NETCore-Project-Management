using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        // ReturnUrl is the URL the user was trying to access before authentication.
        // We preserve and pass it between requests using ReturnUrl property, so the user can
        // be redirected to that URL upon successful authentication
        public string ReturnUrl { get; set; }

        // AuthenticationScheme is in Microsoft.AspNetCore.Authentication namespace
        // Stores the list of external logins (like Facebook, Google etc) that are enabled in our application
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
