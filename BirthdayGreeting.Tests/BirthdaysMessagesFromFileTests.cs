using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class BirthdaysMessagesFromFileTestsRepositories : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CsvEmployeesRepository(@"Resources\employees.txt"), };
            yield return new object[] { new SqlLiteEmployeesRepository(@"Resources\employees.db"), };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class BirthdaysMessagesFromFileTests
    {
        [Theory]
        [ClassData(typeof(BirthdaysMessagesFromFileTestsRepositories))]
        public void CanCreate_AListOfBirthdaysMessages_FromASource(IEmployeesRepository repository)
        {
            List<BirthdayMessage> birthdayMessages = new BirthdayMessagesService(repository).CreateMessages(TestEmployees.John.DateOfBirth);

            List<BirthdayMessage> expectedMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(TestEmployees.John.Name)
            };

            Assert.Equal(expectedMessages, birthdayMessages);
        }
    }
}
