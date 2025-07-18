using CleanArchitecture.Application.Interfaces.Services;
using MediatR;

namespace CleanArchitecture.Application.Feautures.Car.Commands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarCommandRequest>
    {
        private readonly ICarService _carService;

        public CreateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<CreateCarCommandRequest> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.CreateAsync(request, cancellationToken);
            return new CreateCarCommandRequest { message = "Araç Üretildi" };

        }
    }
}
