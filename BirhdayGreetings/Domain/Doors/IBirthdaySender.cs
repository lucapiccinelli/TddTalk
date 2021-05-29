using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Domain.Doors
{
    public interface IBirthdaySender
    {
        void Send(BirthdayEmail emailMessage);
    }
}