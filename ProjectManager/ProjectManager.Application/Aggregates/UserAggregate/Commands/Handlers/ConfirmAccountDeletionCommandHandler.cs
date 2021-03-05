using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectManager.Application.Common;
using ProjectManager.Application.Identity;
using ProjectManager.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Handlers
{
    public class ConfirmAccountDeletionCommandHandler : CommandHandler, IRequestHandler<ConfirmAccountDeletionCommand, bool>
    {
        private readonly UserManager<UserIdentity> _userManager;

        public ConfirmAccountDeletionCommandHandler(IUnitOfWork unitOfWork, UserManager<UserIdentity> userManager) : base(unitOfWork) { }

        public async Task<bool> Handle(ConfirmAccountDeletionCommand request, CancellationToken cancellationToken)
        {
            UserIdentity userIdentity = await _userManager.FindByIdAsync(request.IdentityId);

            bool passwordCheck = await _userManager.CheckPasswordAsync(userIdentity, request.Password);

            if (!passwordCheck) return false;

            var result = await _userManager.DeleteAsync(userIdentity);

            if (result.Succeeded)
            {
                _unitOfWork.UserRepository.RemoveById(userIdentity.UserId);
                return await _unitOfWork.Commit() > 0;
            }

            return false;
        }
    }
}
