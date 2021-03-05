using ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses;
using ProjectManager.Application.Aggregates.UserAggregate.Validators;
using ProjectManager.Application.Common;
using System;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands
{
    public class ConfirmEmailCommand : Command<ConfirmEmailCommandResponse>
    {
        public string Token { get; set; }
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}
