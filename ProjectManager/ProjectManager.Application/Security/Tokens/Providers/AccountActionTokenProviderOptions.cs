using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Security.Tokens.Providers
{
    public class AccountActionTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public string Secret { get; set; }
        public int ExpirationInHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
