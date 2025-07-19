using CleanArchitecture.Application.Interfaces.AutoMapper;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomMapper _customMapper;
        private readonly IMailService _mailService;
        public RegisterCommandHandler(UserManager<AppUser> userManager, ICustomMapper customMapper, IMailService mailService)
        {
            _userManager = userManager;
            _customMapper = customMapper;
            _mailService = mailService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            AppUser user = _customMapper.Map<AppUser, RegisterCommand>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.First().Description);

            // await _mailService.SendMail(user.Email, "Yeni Kullanıcı Kaydı", "<b>Başarıyla Sisteme Kayıt Edildiniz.</b>");

            return new RegisterCommandResponse();




        }
    }
}
