using System;
namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses
{
    public class ConfirmEmailCommandResponse
    {
        public bool UserExists { get; set; } = true;
        public bool? EmailAlreadyConfirmed { get; set; }
        public bool? IsPasswordCorrect { get; set; }
    }
}
