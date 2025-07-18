using MediatR;

namespace CleanArchitecture.Application.Feautures.Car.Commands
{
    public record CreateCarCommand(string name, string model, int enginePower) : IRequest<CreateCarCommandRequest>;
}
