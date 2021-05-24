using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Domain.Usecases;
using BirthdayGreetings.Doors.Repositories.Csv;
using BirthdayGreetings.Doors.Repositories.SqlLite;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class BirthdaysMessagesFromFileTestsRepositories : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CsvRepository(@"Resources\employees.txt"), };
            yield return new object[] { new SqlLiteRepository(@"Resources\employees.db"), };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class BirthdaysMessagesFromFileTests
    {
        [Theory]
        [ClassData(typeof(BirthdaysMessagesFromFileTestsRepositories))]
        public void CanCreate_AListOfBirthdaysMessages_FromASource(IRepository<Employee> repository)
        {
            List<BirthdayMessage> birthdayMessages = new BirthdayStoreService(repository).CreateMessages(TestEmployees.John.DateOfBirth);

            List<BirthdayMessage> expectedMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(TestEmployees.John.Name)
            };

            Assert.Equal(expectedMessages, birthdayMessages);
        }
    }
}
