using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace DataRoom.Service.Interface
{
    public interface IEmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link);
        public bool SendEmailNotifyBidders(string userEmail, string link);
    }
}
