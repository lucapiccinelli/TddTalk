namespace BirthdayGreetings.Domain.Doors
{
    public interface IEmailSender
    {
        void Send(EmailServiceConfiguration configuration, string from, string to, string body);
    }
}