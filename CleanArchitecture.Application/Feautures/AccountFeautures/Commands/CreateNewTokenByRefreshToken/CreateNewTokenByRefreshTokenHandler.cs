using CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.CreateNewTokenByRefreshToken
{
    public class CreateNewTokenByRefreshTokenHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
    {


        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public CreateNewTokenByRefreshTokenHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByIdAsync(request.userId);

            if (user == null) throw new Exception("Böyle bir kullanıcı yok");

            var refreshTokenExpire = user.RefreshTokenExpire;
            var refreshToken = user.RefreshToken;

            if (refreshToken != request.refrehToken) throw new Exception("Refresh Token Geçerli Değil");


            if (refreshTokenExpire < DateTime.Now) throw new Exception("Refreh Token Süresi Dolmuş");

            var response = await _jwtProvider.CreateTokenAsync(user);

            return response;





        }
    }
}
