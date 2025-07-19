using CleanArchitecture.Application.Interfaces.AutoMapper;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomMapper _customMapper;
        public RegisterCommandHandler(UserManager<AppUser> userManager, ICustomMapper customMapper)
        {
            _userManager = userManager;
            _customMapper = customMapper;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            AppUser user = _customMapper.Map<AppUser, RegisterCommand>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.First().Description);

            return new RegisterCommandResponse();




        }
    }
}
