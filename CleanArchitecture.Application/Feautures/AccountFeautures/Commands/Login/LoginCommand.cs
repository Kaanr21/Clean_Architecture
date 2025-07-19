using MediatR;

namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login
{
    public record LoginCommand(string userNameOrEmail, string password) : IRequest<LoginCommandResponse>;

}
