namespace CleanArchitecture.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendMail(string toEmail, string subject, string body);
    }
}
