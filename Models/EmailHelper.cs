using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
//using Microsoft.Extensions.Logging;

namespace DataRoom.Models
{
    public class EmailHelper
    {
        //private readonly ILogger<EmailHelper> _logger;

        //public EmailHelper(ILogger<EmailHelper> logger)
        //{
        //    _logger = logger;
        //}

        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("sthay@mof.gov.tl");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("sthay@mof.gov.tl", "For_security_reason_I_took_out_the_real_password_already");
            smtp.Host = "webmail.mof.gov.tl";

            // Exchange listens for authenticated SMTP client submissions
            // on port 587 on the Client Access server
            smtp.Port = 25;

            // Smtp Email ID and Password For authentication
            //smtp.EnableSsl = true;

            try
            {
                smtp.Send(mailMessage);
                
                return true;
            }
            catch (Exception ex)
            {
                // log exception
                //_logger.LogError($"Exception Occured : {ex}");

                //ViewBag.ErrorTitle = "Error occurs";
                //ViewBag.ErrorMessage = $"Exception Occured : {ex}";

                return false;
            }
            
        }
    }
}
