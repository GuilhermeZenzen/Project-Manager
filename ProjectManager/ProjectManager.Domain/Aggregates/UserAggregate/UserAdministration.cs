using System;
using ProjectManager.Domain.Common.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Aggregates.UserAggregate
{
    public class UserAdministration : Entity
    {
        public Guid AdministratorId { get; private set; }
        public Guid AdministeredId { get; private set; }
        public RoleEnum RoleId { get; private set; }

        public User Administrator { get; private set; }
        public User Administered { get; private set; }
        public Role Role { get; private set; }

        protected UserAdministration() { }

        public UserAdministration(Guid administratorId, Guid administered, RoleEnum role)
        {
            AdministratorId = administratorId;
            AdministeredId = administered;
            RoleId = role;
        }

        public void ChangeRole(RoleEnum newRole) => RoleId = newRole;
    }
}
