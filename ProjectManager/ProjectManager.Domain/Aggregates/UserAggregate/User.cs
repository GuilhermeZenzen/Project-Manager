using System;
using System.Collections.Generic;
using ProjectManager.Domain.Common.Entities;
using ProjectManager.Domain.Enums;
using ProjectManager.Domain.ValueObjects;

namespace ProjectManager.Domain.Aggregates.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        //public Name Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public virtual IList<UserAdministration> Administrators { get; private set; } = new List<UserAdministration>();
        public virtual IList<UserAdministration> Personnel { get; private set; } = new List<UserAdministration>();

        public User() { }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            ValidateName();
        }

        private void ValidateName()
        {
            if (string.IsNullOrEmpty(FirstName))
                AddValidationError("Invalid First Name", "First name is required");

            if (string.IsNullOrEmpty(LastName))
                AddValidationError("Invalid Last Name", "Last name is required");
        }

        public UserAdministration AddAdministrator(Guid superiorId, RoleEnum role)
        {
            UserAdministration administration = new UserAdministration(superiorId, Id, role);
            Administrators.Add(administration);

            return administration;
        }
        public UserAdministration AddAdministrator(UserAdministration administration)
        {
            Administrators.Add(administration);

            return administration;
        }

        public UserAdministration RemoveAdministrator(UserAdministration administration)
        {
            Administrators.Remove(administration);

            return administration;
        }

        public UserAdministration AddAdministered(Guid subordinateId, RoleEnum role)
        {
            UserAdministration administration = new UserAdministration(Id, subordinateId, role);
            Personnel.Add(administration);

            return administration;
        }

        public UserAdministration AddAdministered(UserAdministration administration)
        {
            Personnel.Add(administration);

            return administration;
        }

        public UserAdministration RemoveAdministered(UserAdministration administration)
        {
            Personnel.Remove(administration);

            return administration;
        }
    }
}
