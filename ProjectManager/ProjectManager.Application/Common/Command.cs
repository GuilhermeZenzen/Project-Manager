using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace ProjectManager.Application.Common
{
    public abstract class Command<RT> : IRequest<RT>
    {
        public virtual bool IsValid() => true;

        protected bool Validate<T>(AbstractValidator<T> validator) where T: Command<RT>
        {
            var validationResult = validator.Validate((T)this);

            return validationResult.IsValid;
        }
    }
}
