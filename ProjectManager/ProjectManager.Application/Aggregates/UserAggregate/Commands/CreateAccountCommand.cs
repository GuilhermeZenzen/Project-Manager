using ProjectManager.Application.Common;
using ProjectManager.Application.Aggregates.UserAggregate.Validators;
using Microsoft.AspNetCore.Identity;
using ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands
{
    public class CreateAccountCommand : Command<CreateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }

        public CreateAccountCommand() { }

        public CreateAccountCommand(string firstName, string lastName, string email, string password, string confirmedPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            ConfirmedPassword = confirmedPassword;
        }

        public override bool IsValid() => Validate(new CreateUserCommandValidator());
    }
}
