using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Abstraction
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class MyBaseApiController : ControllerBase
    {
        protected IMediator _mediator;

        protected MyBaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
