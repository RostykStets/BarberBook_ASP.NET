namespace BusinessLogicLayer.Services.Identity
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
