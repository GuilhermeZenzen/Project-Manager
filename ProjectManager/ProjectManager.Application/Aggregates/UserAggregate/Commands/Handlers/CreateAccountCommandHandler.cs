using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses;
using ProjectManager.Application.Common;
using ProjectManager.Application.Identity;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Aggregates.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Handlers
{
    public class CreateAccountCommandHandler : CommandHandler, IRequestHandler<CreateAccountCommand, CreateUserResponse>
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly IEmailSender _emailSender;

        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, UserManager<UserIdentity> userManager, IEmailSender emailSender) : base(unitOfWork) => (_userManager, _emailSender) = (userManager, emailSender);

        public async Task<CreateUserResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            User user = new User(request.FirstName, request.LastName);

            UserIdentity identity = new UserIdentity
            {
                UserName = request.Email,
                Email = request.Email
            };
            identity.LinkUser(user);

            var result = await _userManager.CreateAsync(identity, request.Password);

            if (result.Succeeded)
            {
                string cToken = await _userManager.GenerateEmailConfirmationTokenAsync(identity);
                await _emailSender.SendEmailConfirmation(identity.Email, $"{user.FirstName} {user.LastName}", identity.Id.ToString(), cToken);
            }

            return new CreateUserResponse { Succeeded = result.Succeeded, Errors = result.Errors };
        }
    }
}
