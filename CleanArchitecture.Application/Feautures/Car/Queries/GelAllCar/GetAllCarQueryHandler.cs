using CleanArchitecture.Application.Interfaces.AutoMapper;
using CleanArchitecture.Application.Interfaces.UnitOfWork;
using MediatR;

namespace CleanArchitecture.Application.Feautures.CarFeautures.Queries.GelAllCar
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IList<CleanArchitecture.Domain.Entities.Car>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _mapper;

        public GetAllCarQueryHandler(IUnitOfWork unitOfWork, ICustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<Domain.Entities.Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {

            //var obj = _mapper.Map<IList< CleanArchitecture.Domain.Entities.Car >, GetAllCarQuery>(request);

            IList<CleanArchitecture.Domain.Entities.Car> cars = (IList<Domain.Entities.Car>)await _unitOfWork.Repository<CleanArchitecture.Domain.Entities.Car>().GetAllAsync();

            return cars;
        }
    }
}
