using CleanArchitecture.Application.Feautures.Car.Commands;

namespace CleanArchitecture.Application.Interfaces.Services
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarCommand request, CancellationToken token);
    }
}
