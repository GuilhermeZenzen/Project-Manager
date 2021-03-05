using ProjectManager.Application.Common;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands
{
    public class ConfirmAccountDeletionCommand : Command<bool>
    {
        public string IdentityId { get; set; }
        public string Password { get; set; }

        public ConfirmAccountDeletionCommand(string identityId, string password) => (IdentityId, Password) = (identityId, password);
    }
}
