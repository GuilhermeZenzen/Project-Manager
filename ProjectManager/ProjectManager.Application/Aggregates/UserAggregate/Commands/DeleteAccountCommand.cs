using ProjectManager.Application.Common;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands
{
    public class DeleteAccountCommand : Command<bool>
    {
        public string Email { get; set; }

        public DeleteAccountCommand(string email) => Email = email;
    }
}
