using ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses;
using ProjectManager.Application.Common;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands
{
    public class SignInCommand : Command<SignInResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public SignInCommand() { }

        public SignInCommand(string email, string password) => (Email, Password) = (email, password);
    }
}
