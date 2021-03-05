namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses
{
    public class SignInResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public bool IsLockedOut { get; set; }
    }
}
