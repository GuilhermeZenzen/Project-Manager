using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses
{
    public class CreateUserResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
