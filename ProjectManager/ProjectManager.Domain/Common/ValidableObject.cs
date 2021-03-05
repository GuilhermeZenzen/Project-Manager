using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace ProjectManager.Domain.Common
{
    public abstract class ValidableObject
    {
        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public void AddValidationError(string error, string description)
        {
            ValidationResult.Errors.Add(new ValidationFailure(error, description));
        }

        public void AddValidationError(ValidationFailure error)
        {
            ValidationResult.Errors.Add(error);
        }

        public void AddValidationErrors(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                AddValidationError(error);
            }
        }

        public virtual bool IsValid() => ValidationResult.IsValid;
    }
}
