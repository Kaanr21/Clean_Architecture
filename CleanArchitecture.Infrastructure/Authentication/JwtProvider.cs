using CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<LoginCommandResponse> CreateToken(AppUser user)
        {

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("Email",user.Email)
            };
            DateTime expire = DateTime.Now.AddHours(1);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expire,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpire = expire.AddMinutes(20);

            LoginCommandResponse response = new LoginCommandResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                RefreshTokenExpire = user.RefreshTokenExpire,
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,

            };

            return response;
        }
    }
}
