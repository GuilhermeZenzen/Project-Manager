using FluentValidation;
using ProjectManager.Application.Aggregates.UserAggregate.Commands;

namespace ProjectManager.Application.Aggregates.UserAggregate.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateUserCommandValidator()
        {
            //RuleFor(c => c.FirstName).NotNull().NotEmpty();
            //RuleFor(c => c.LastName).NotNull().NotEmpty();
            //RuleFor(c => c.Email).NotNull().NotEmpty().EmailAddress();
            //RuleFor(c => c.Password).NotNull().NotEmpty().MinimumLength(8);
            RuleFor(c => c.ConfirmedPassword).Equal(c => c.Password);
        }
    }
}
