using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses;
using ProjectManager.Application.Common;
using ProjectManager.Application.Common.Utility;
using ProjectManager.Application.Identity;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Aggregates.UserAggregate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Handlers
{
    public class SignInCommandHandler : CommandHandler, IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly TokenConfiguration _authentication;

        public SignInCommandHandler(IUnitOfWork unitOfWork, UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager, IOptions<TokenConfiguration> authenticationOptions) : base(unitOfWork)
        {
            (_userManager, _signInManager, _authentication) = (userManager, signInManager, authenticationOptions.Value);
        }

        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

            string userId = null, token = null;
            
            if (result.Succeeded)
            {
                userId = (await _unitOfWork.UserRepository.Get((await _userManager.FindByEmailAsync(request.Email)).UserId)).Id.ToString();
                token = TokenGenerator.GenerateJwt(_authentication, new List<Claim> { new Claim("userId", userId), new Claim("userEmail", request.Email) });
            }

            return new SignInResponse
            {
                UserId = userId,
                Token = token,
                IsLockedOut = result.IsLockedOut
            };
        }
    }
}
