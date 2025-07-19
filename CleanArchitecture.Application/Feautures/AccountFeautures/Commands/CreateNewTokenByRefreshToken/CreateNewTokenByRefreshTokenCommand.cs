using CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login;
using MediatR;

namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.CreateNewTokenByRefreshToken
{
    public record CreateNewTokenByRefreshTokenCommand(string userId, string refrehToken) : IRequest<LoginCommandResponse>;


}
