using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Email.Gmail
{
    public class GmailService
    {
        private readonly Credentials _credentials;
        private readonly IEmailSender _emailSender;

        public GmailService(Credentials credentials, IEmailSender emailSender)
        {
            _credentials = credentials;
            _emailSender = emailSender;
        }
        public GmailService(Credentials credentials) : this(credentials, new EmailSender())
        {
        }

        public void Send(BirthdayEmail emailMessage, EmailAddress from)
        {
            var configuration = new EmailServiceConfiguration
            {
                Credentials = _credentials,
                Port = 587,
                Smtp = "smtp.gmail.com",
                Ssl = true
            };
            _emailSender.Send(configuration, from.Value, emailMessage.Recipient.Value, emailMessage.Message.ToString());
        }
    }
}