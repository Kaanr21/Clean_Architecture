using CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Register;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    public class AccountController : MyBaseApiController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand request, CancellationToken token)
        {
            RegisterCommandResponse response = await _mediator.Send(request, token);

            return Ok(response);
        }

    }
}
