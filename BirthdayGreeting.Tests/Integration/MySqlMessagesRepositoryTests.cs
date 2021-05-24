using System;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests.Integration
{
    public class MySqlMessagesRepositoryTests
    {
        [Fact]
        void CanReadMessagesFromDb()
        {
            MySqlMessagesRepository repository = new MySqlMessagesRepository();

            List<BirthdayMessage> expectedBirthdayMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(TestEmployees.John.Name),
                new BirthdayMessage(TestEmployees.Mary.Name)
            };

            List<BirthdayMessage> actualBirthdayMessages = repository.ReadAll();
            Assert.Equal(expectedBirthdayMessages, actualBirthdayMessages);
        }
    }

    public class MySqlMessagesRepository: IRepository<BirthdayMessage>
    {
        public List<BirthdayMessage> ReadAll()
        {
            return new List<BirthdayMessage>
            {
                new BirthdayMessage(TestEmployees.John.Name),
                new BirthdayMessage(TestEmployees.Mary.Name)
            };
        }

        public void New(BirthdayMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
