namespace CleanArchitecture.Application.Feautures.AccountFeautures.Commands.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpire { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
