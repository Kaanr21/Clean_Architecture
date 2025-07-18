using CleanArchitecture.Application.Feautures.Car.Commands;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{

    public class ValuesController : MyBaseApiController
    {
        public ValuesController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand request, CancellationToken token)
        {
            var message = await _mediator.Send(request, token);

            return Ok(message);


        }



    }
}
