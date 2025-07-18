using CleanArchitecture.Application.Interfaces.AutoMapper;
using CleanArchitecture.Application.Interfaces.UnitOfWork;
using MediatR;

namespace CleanArchitecture.Application.Feautures.Car.Commands
{

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _mapper;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork, ICustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCarCommandRequest> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {

            var car = _mapper.Map<CleanArchitecture.Domain.Entities.Car, CreateCarCommand>(request);

            await _unitOfWork.Repository<CleanArchitecture.Domain.Entities.Car>().AddAsync(car, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return new CreateCarCommandRequest { message = "Araç Üretildi" };
        }
    }
}
