using MediatR;


namespace CleanArchitecture.Application.Feautures.CarFeautures.Queries.GelAllCar
{
    public record GetAllCarQuery() : IRequest<IList<CleanArchitecture.Domain.Entities.Car>>;

}
