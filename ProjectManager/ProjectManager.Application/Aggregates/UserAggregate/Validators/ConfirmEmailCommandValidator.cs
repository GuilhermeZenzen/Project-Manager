using FluentValidation;
using ProjectManager.Application.Aggregates.UserAggregate.Commands;

namespace ProjectManager.Application.Aggregates.UserAggregate.Validators
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(c => c.Token).NotNull().NotEmpty().WithMessage("Token can't be empty");
            RuleFor(c => c.Id).NotNull().NotEmpty().WithMessage("Id can't be empty");
            RuleFor(c => c.Password).NotNull().NotEmpty().WithMessage("Password can't be empty");
        }
    }
}
