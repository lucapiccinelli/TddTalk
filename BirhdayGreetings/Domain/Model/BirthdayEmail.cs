namespace BirthdayGreetings.Domain.Model
{
    public class BirthdayEmail
    {
        public EmailAddress Recipient { get; }
        public BirthdayMessage Message { get; }

        public BirthdayEmail(EmailAddress recipient, BirthdayMessage message)
        {
            Recipient = recipient;
            Message = message;
        }
    }
}