using System;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class BirthdaysMessagesFromFileTests
    {

        [Fact]
        public void CanCreate_AListOfBirthdaysMessages_FromFile()
        {
            string filename = @"Resources\employees.txt";
            List<BirthdayMessage> birthdayMessages = BirthdayMessages.FromFile(filename, TestEmployees.John.DateOfBirth);

            List<BirthdayMessage> expectedMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(TestEmployees.John.Name)
            };

            Assert.Equal(expectedMessages, birthdayMessages);
        }
    }
}
