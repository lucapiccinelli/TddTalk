using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Email.Gmail
{
    public class GmailBirthdaySender : IBirthdaySender
    {
        private readonly EmailAddress _from;
        private readonly Credentials _credentials;
        private readonly IEmailSender _emailSender;

        public GmailBirthdaySender(EmailAddress from, Credentials credentials, IEmailSender emailSender)
        {
            _from = from;
            _credentials = credentials;
            _emailSender = emailSender;
        }
        public GmailBirthdaySender(EmailAddress from, Credentials credentials) : this(from, credentials, new EmailSender())
        {
        }

        public void Send(BirthdayEmail emailMessage)
        {
            var configuration = new EmailServiceConfiguration
            {
                Credentials = _credentials,
                Port = 587,
                Smtp = "smtp.gmail.com",
                Ssl = true
            };
            _emailSender.Send(configuration, _from.Value, emailMessage.Recipient.Value, emailMessage.Message.ToString());
        }
    }
}