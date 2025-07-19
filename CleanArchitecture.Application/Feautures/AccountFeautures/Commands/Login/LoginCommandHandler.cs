using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtProvider _jwtProvider;


        public LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user =
                _userManager.Users.Where(a =>
                a.Email == request.userNameOrEmail ||
                a.UserName == request.userNameOrEmail
                ).FirstOrDefault();


            if (user == null) throw new Exception("Kullanıcı Bulunamadı");

            var result = await _userManager.CheckPasswordAsync(user, request.password);

            if (result)
            {
                LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
                return response;
            }

            throw new Exception("Yanlış Şifre Girdiniz!!");

        }
    }
}
