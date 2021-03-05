using ProjectManager.Domain.Aggregates.UserAggregate;
using ProjectManager.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string LocalPart { get; private set; }
        public string Domain { get; private set; }

        protected Email() { }

        public Email(string email)
        {
            string[] emailSplit = email.Split('@');

            if (emailSplit.Length < 2)
            {
                AddValidationError("Invalid Email", "Email doesn't contain an local part or domain");
            }
            else if (emailSplit.Length > 2)
            {
                AddValidationError("Invalid Email", "Email contains undesirable component");
            }
            else
            {
                LocalPart = emailSplit[0];
                Domain = emailSplit[1];
            }
        }

        public override string ToString()
        {
            return LocalPart + "@" + Domain;
        }

        public override bool Equals(object obj)
        {
            if (obj is string emailStr)
                return ToString().Equals(emailStr);

            return base.Equals(obj);
        }
    }
}
