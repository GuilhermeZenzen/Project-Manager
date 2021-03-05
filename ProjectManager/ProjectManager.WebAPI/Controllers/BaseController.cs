using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator) => _mediator = mediator;

        protected ValidationResult ValidateCommand<TCommand, TValidator>(TCommand command, Action<TValidator> extraRules = null) where TValidator: AbstractValidator<TCommand>, new()
        {
            TValidator validator = new TValidator();
            extraRules?.Invoke(validator);
            return validator.Validate(command);
        }
    }
}
