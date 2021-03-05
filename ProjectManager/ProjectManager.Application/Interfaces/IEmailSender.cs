using System.Threading.Tasks;

namespace ProjectManager.Application.Interfaces
{
    public interface IEmailSender
    {
        public Task<bool> SendEmailConfirmation(string email, string name, string userId, string token);
        public Task<bool> SendDeleteConfirmation(string email, string token);
    }
}
