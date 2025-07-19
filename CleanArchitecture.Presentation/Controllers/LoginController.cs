using CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    public class LoginController : MyBaseApiController
    {
        public LoginController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken token)
        {
            var response = await _mediator.Send(request, token);
            return Ok(response);

        }
    }
}
