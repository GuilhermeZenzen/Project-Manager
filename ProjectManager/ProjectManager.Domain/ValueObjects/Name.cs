using ProjectManager.Domain.Common.ValueObjects;
using System;

namespace ProjectManager.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string LastName { get; private set; }

        protected Name() { }

        public Name(string firstName, string surname, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                AddValidationError("Invalid Name", "Fullname is required");

            FirstName = firstName;
            Surname = string.IsNullOrEmpty(surname) ? null : surname;
            LastName = lastName;
        }

        public Name(string fullName)
        {
            string[] names = fullName.Split(' ');

            if (names.Length < 2)
                AddValidationError("Invalid Name", "Fullname is required");
            else
            {
                FirstName = names[0];
                Surname = names.Length > 2 ? string.Join(" ", names, 1, names.Length - 2) : null;
                LastName = names[names.Length - 1];
            }
        }

        public override string ToString() => $"{FirstName} {Surname} {LastName}";
    }
}
