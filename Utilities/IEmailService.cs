using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.Utilities
{
    public interface IEmailService
    {
        //bool SendMail(EmailData emailData);

        bool SendEmail(string emailTo, string subjectLine, string link);
        bool SendEmailConfirmationTemplate(string emailTo, string confirmationLink);

    }
}
