using System.Net;
using System.Net.Mail;
using BirthdayGreetings.Domain.Doors;

namespace BirthdayGreetings.Doors.Email
{
    public class EmailSender : IEmailSender
    {
        public void Send(EmailServiceConfiguration configuration, string from, string to, string body)
        {
            var client = new SmtpClient(configuration.Smtp, configuration.Port)
            {
                EnableSsl = configuration.Ssl,
                Credentials = new NetworkCredential(configuration.Credentials.Username, configuration.Credentials.Password)
            };

            client.Send(new MailMessage(from, to)
            {
                Body = body
            });
        }
    }
}