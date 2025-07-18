using CleanArchitecture.Application.Feautures.Car.Commands;
using CleanArchitecture.Application.Interfaces.AutoMapper;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly ICustomMapper _mapper;

        public CarService(AppDbContext context, ICustomMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken token)
        {
            var car = _mapper.Map<Car, CreateCarCommand>(request);

            await _context.AddAsync(car, token);
            await _context.SaveChangesAsync(token);

        }


    }
}
