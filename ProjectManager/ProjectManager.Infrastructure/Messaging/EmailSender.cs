using MimeKit;
using MailKit.Net.Smtp;
using ProjectManager.Application.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ProjectManager.Infrastructure.Messaging
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderConfiguration _senderConfiguration;
        private readonly AppConfirmationUrls _appConfirmationUrls;

        public EmailSender(IOptions<EmailSenderConfiguration> senderConfiguration, IOptions<AppConfirmationUrls> appConfirmationUrls) => (_senderConfiguration, _appConfirmationUrls) = (senderConfiguration.Value, appConfirmationUrls.Value);

        public async Task<bool> SendEmailConfirmation(string email, string name, string userId, string token)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_senderConfiguration.Name, _senderConfiguration.Address));
            message.To.Add(new MailboxAddress(name, email));
            message.Subject = "Project Manager Email Confirmation";
            message.Body = new TextPart("plain") { Text = $"{_appConfirmationUrls.EmailConfirm}?userId={userId}&token={token}" };

            using var client = new SmtpClient();

            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            await client.ConnectAsync(_senderConfiguration.Host, _senderConfiguration.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_senderConfiguration.Address, _senderConfiguration.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            return true;
        }

        public async Task<bool> SendDeleteConfirmation(string email, string token)
        {
            throw new NotImplementedException();
        }
    }
}
