using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ProjectManager.Application.Aggregates.UserAggregate.Commands;

namespace ProjectManager.WebAPI.Controllers
{
    [Route("/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator) => _mediator = mediator;

        [Route("/delete")]
        [ActionName("POST")]
        public async Task<IActionResult> DeleteAccount(DeleteAccountCommand request)
        {
            string tokenUserEmail = User.Claims.FirstOrDefault(claim => claim.Type.Equals("userEmail"))?.Value;

            if (tokenUserEmail == null || !tokenUserEmail.Equals(request.Email)) return BadRequest();

            bool result = await _mediator.Send(request);

            if (result)
                return Ok();

            return NotFound(request);
        }

        [Route("/delete/confirm")]
        [ActionName("POST")]
        public async Task<IActionResult> ConfirmAccountDeletion(ConfirmAccountDeletionCommand request)
        {
            if (User.Claims.FirstOrDefault(claim => claim.Type.Equals("deleteAccount")) == null) return BadRequest();

            string tokenUserPassword = User.Claims.FirstOrDefault(claim => claim.Type.Equals("deleteAccount"))?.Value;
            return null;
            //if (tokenUserPassword ==)
        }
    }
}