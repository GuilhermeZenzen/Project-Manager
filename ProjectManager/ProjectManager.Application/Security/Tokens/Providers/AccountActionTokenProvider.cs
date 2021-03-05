using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjectManager.Application.Common.Utility;
using ProjectManager.Application.Identity;

namespace ProjectManager.Application.Security.Tokens.Providers
{
    public class AccountActionTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser: UserIdentity
    {
        public AccountActionTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<AccountActionTokenProviderOptions> options) : base(dataProtectionProvider, options) { }

        public async override Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
        {
            var options = (AccountActionTokenProviderOptions)Options;
            return TokenGenerator.GenerateJwt(options.Secret, options.ExpirationInHours, options.Issuer, options.Audience, new List<Claim> { new Claim("userId", await manager.GetUserIdAsync(user)), new Claim("purpose", purpose) });
        }

        public override Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
        {
            
        }
    }
}
