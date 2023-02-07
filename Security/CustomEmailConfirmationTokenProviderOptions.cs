using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.Security
{
    public class CustomEmailConfirmationTokenProviderOptions
        : DataProtectionTokenProviderOptions
    { }
}
