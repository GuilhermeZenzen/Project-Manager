using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses;
using ProjectManager.Application.Common;
using ProjectManager.Application.Identity;
using ProjectManager.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Handlers
{
    public class ConfirmEmailCommandHandler : CommandHandler, IRequestHandler<ConfirmEmailCommand, ConfirmEmailCommandResponse>
    {
        private readonly UserManager<UserIdentity> _userManager;

        public ConfirmEmailCommandHandler(IUnitOfWork unitOfWork, UserManager<UserIdentity> userManager) : base(unitOfWork) => _userManager = userManager;

        public async Task<ConfirmEmailCommandResponse> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            UserIdentity userIdentity = await _userManager.FindByIdAsync(request.Id.ToString());

            if (userIdentity == null)
            {
                return new ConfirmEmailCommandResponse { UserExists = false };
            }

            if (userIdentity.EmailConfirmed)
            {
                return new ConfirmEmailCommandResponse { EmailAlreadyConfirmed = true };
            }

            if (await _userManager.CheckPasswordAsync(userIdentity, request.Password))
            {
                await _userManager.ConfirmEmailAsync(userIdentity, request.Token);

                return new ConfirmEmailCommandResponse { EmailAlreadyConfirmed = false, IsPasswordCorrect = true };
            }

            return new ConfirmEmailCommandResponse { EmailAlreadyConfirmed = false, IsPasswordCorrect = false };
        }
    }
}
