namespace FinalProject.Core.Services
{
    public interface IEmailSender
    {
        Task SendEmail(string to, string subject, string body, byte[] document);

    }
}
