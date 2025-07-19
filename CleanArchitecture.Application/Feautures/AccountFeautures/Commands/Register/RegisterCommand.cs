using MediatR;

namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Register
{
    public record RegisterCommand(string UserName, string Email, string Password) : IRequest<RegisterCommandResponse>;

}
