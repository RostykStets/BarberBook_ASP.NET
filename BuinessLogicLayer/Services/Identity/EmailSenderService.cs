using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace BusinessLogicLayer.Services.Identity
{
    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var sender = "andrii.skvarko@lnu.edu.ua";
            var username = "barberbook";
            var pw = "DjNXrp7jl66eQ3dM";

            var client = new SmtpClient("mail.smtp2go.com", 2525)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    userName: username,
                    password: pw
                    )
            };

            return client.SendMailAsync(
                new MailMessage(
                    from: sender,
                    to: email,
                    subject: subject,
                    message
                    ));
        }
    }
}
