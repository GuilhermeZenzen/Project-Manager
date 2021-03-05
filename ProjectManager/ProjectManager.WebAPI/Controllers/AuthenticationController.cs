using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation;
using ProjectManager.Application.Aggregates.UserAggregate.Commands;
using ProjectManager.Application.Aggregates.UserAggregate.Commands.Responses;
using ProjectManager.Application.Aggregates.UserAggregate.Validators;

namespace ProjectManager.WebAPI.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator) : base(mediator) { }

        [Route("/sign-up")]
        public async Task<IActionResult> SignUp(CreateAccountCommand signUp)
        {
            if (!signUp.IsValid())
            {
                return BadRequest(new { confirmedPassword = signUp.ConfirmedPassword });
            }

            CreateUserResponse response = await _mediator.Send(signUp);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(new { errors = response.Errors });
        }

        [Route("/sign-in")]
        public async Task<IActionResult> SignIn(SignInCommand signIn)
        {
            SignInResponse response = await _mediator.Send(signIn);

            if (response.Token != null)
            {
                return Ok(new { userId = response.UserId, token = response.Token });
            }

            return BadRequest(new { isLockedOut = response.IsLockedOut });
        }
    
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            var validation = ValidateCommand<ConfirmEmailCommand, ConfirmEmailCommandValidator>(command, v =>
            {
                v.RuleFor(c => c.Id.ToString()).Equal(User.Claims.FirstOrDefault(c => c.Value.Equals("userId"))?.Value);
            });
            
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var response = await _mediator.Send(command);

            if (!response.UserExists)
            {
                return BadRequest(new string[] { "User doesn't exist" });
            }

            if (response.EmailAlreadyConfirmed.Value)
            {
                return BadRequest(new string[] { "User email is already confirmed" });
            }

            if (!response.IsPasswordCorrect.Value)
            {
                return BadRequest(new string[] { "Password is incorrect" });
            }

            return Ok();
        }
    }
}