using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.Utilities
{
    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings = null;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmail(string emailTo, string subjectLine, string link)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.From));
            email.To.Add(MailboxAddress.Parse(emailTo));

            email.Subject = subjectLine;

            var builder = new BodyBuilder();
            builder.HtmlBody = link;
            email.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                try
                {
                    smtp.CheckCertificateRevocation = false;
                    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (_emailSettings.UseSSL)
                    {
                        smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.SslOnConnect);
                    }
                    else if (_emailSettings.UseStartTls)
                    {
                        smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                    }

                    smtp.AuthenticationMechanisms.Remove("XOAUTH2");

                    smtp.Authenticate(_emailSettings.From, _emailSettings.Password);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                    smtp.Dispose();

                    return true;
                }
                catch (Exception)
                {
                    //log an error message or throw an exception or both.
                    return false;
                }
            }
        }

        public bool SendEmailConfirmationTemplate(string emailTo, string confirmationLink)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\wwwroot\\html\\SendMailTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("{EmailTo}", emailTo).Replace("{ConfirmationLink}", confirmationLink);

            var email = new MimeMessage();
            
            email.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.From));

            email.To.Add(MailboxAddress.Parse(emailTo));

            email.Subject = $"Welcome {emailTo}";

            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();

            // Uncomment log when in production environment
            using (var smtp = new SmtpClient(new ProtocolLogger(Directory.GetCurrentDirectory() + "\\Logs\\smtp.log", true)))
            {
                try
                {
                    smtp.CheckCertificateRevocation = false;
                    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (_emailSettings.UseSSL)
                    {
                        smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.SslOnConnect);
                    }
                    else if (_emailSettings.UseStartTls)
                    {
                        smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                    }

                    smtp.AuthenticationMechanisms.Remove("XOAUTH2");

                    smtp.Authenticate(_emailSettings.From, _emailSettings.Password);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                    smtp.Dispose();

                    return true;
                }
                catch (Exception)
                {
                    //log an error message or throw an exception or both.
                    return false;
                }
            }
        }
    }
}
