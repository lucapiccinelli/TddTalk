using BirthdayGreetings.Doors.Email;

namespace BirthdayGreetings.Domain.Doors
{
    public interface IEmailSenderFactory
    {
        IEmailSender CreateService(EmailServiceConfiguration configuration);
    }
}