using CleanArchitecture.Application.Feautures.AccountFeautures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login;
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


        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken token)
        {
            var response = await _mediator.Send(request, token);
            return Ok(response);

        }


        [HttpPost]
        public async Task<IActionResult> CreateNewTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken token)
        {
            var response = await _mediator.Send(request, token);
            return Ok(response);

        }

    }
}
