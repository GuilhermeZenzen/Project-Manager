using FluentValidation.Results;

namespace ProjectManager.Domain.Common.ValueObjects
{
    public abstract class ValueObject : ValidableObject
    {
        protected ValueObject() { }
    }
}
