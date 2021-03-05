using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectManager.Application.Common;
using ProjectManager.Application.Common.Utility;
using ProjectManager.Application.Identity;
using ProjectManager.Application.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Handlers
{
    public class DeleteAccountCommandHandler : CommandHandler, IRequestHandler<DeleteAccountCommand, bool>
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly TokenConfiguration _authentication;
        private readonly IEmailSender _emailSender;

        public DeleteAccountCommandHandler(IUnitOfWork unitOfWork, UserManager<UserIdentity> userManager, TokenConfiguration authentication, IEmailSender emailSender) : base(unitOfWork)
        {
            _userManager = userManager;
            _authentication = authentication;
            _emailSender = emailSender;
        }

        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            UserIdentity userIdentity = await _userManager.FindByEmailAsync(request.Email);

            if (userIdentity == null) return false;

            //bool emailSent = await _emailSender.SendDeleteConfirmation(TokenGenerator.GenerateJwt(_authentication, new List<Claim> { new Claim("identityId", userIdentity.Id.ToString()), new Claim("deleteAccount", "true") }));

            //return emailSent;
            return true;
        }
    }
}
