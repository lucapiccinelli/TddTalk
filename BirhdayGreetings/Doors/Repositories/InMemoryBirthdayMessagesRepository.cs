using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Repositories
{
    public class InMemoryBirthdayMessagesRepository: IRepository<BirthdayMessage>
    {
        private readonly List<BirthdayMessage> _birthdayMessages;

        public InMemoryBirthdayMessagesRepository()
        {
            _birthdayMessages = new List<BirthdayMessage>();
        }

        public List<BirthdayMessage> ReadAll() => _birthdayMessages;
        public void New(BirthdayMessage message)
        {
            _birthdayMessages.Add(message);
        }
    }
}