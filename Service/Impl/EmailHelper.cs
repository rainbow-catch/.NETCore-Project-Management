using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using DataRoom.Service.Interface;
using DataRoom.Models;

namespace DataRoom.Service.Impl
{
    public class EmailHelper : IEmailHelper
    {
        private readonly ILogger<IEmailHelper> _logger;
        private IConfiguration _config;

        public EmailHelper(ILogger<IEmailHelper> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("sthay@mof.gov.tl");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            var smtpConfig = _config.GetSection("SMTP").Get<SmtpConfig>();
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(smtpConfig.User??"", smtpConfig.Password??"");
            smtp.Host = smtpConfig.Host;

            // Exchange listens for authenticated SMTP client submissions
            // on port 587 on the Client Access server
            smtp.Port = smtpConfig.Port;

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
        public bool SendEmailNotifyBidders(string userEmail, string link)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("sthay@mof.gov.tl");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Project Updated";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            var smtpConfig = _config.GetSection("SMTP").Get<SmtpConfig>();
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(smtpConfig.User ?? "", smtpConfig.Password ?? "");
            smtp.Host = smtpConfig.Host;

            // Exchange listens for authenticated SMTP client submissions
            // on port 587 on the Client Access server
            smtp.Port = smtpConfig.Port;

            //Email Sender
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
