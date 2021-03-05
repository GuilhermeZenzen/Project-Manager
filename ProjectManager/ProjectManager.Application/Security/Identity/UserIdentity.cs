using System;
using Microsoft.AspNetCore.Identity;
using ProjectManager.Domain.Aggregates.UserAggregate;

namespace ProjectManager.Application.Identity
{
    public class UserIdentity : IdentityUser<Guid>
    {
        public Guid UserId { get; private set; }

        public User User { get; private set; }

        public void LinkUser(Guid userId) => UserId = userId;

        public void LinkUser(User user) => (UserId, User) = (user.Id, user);
    }
}
