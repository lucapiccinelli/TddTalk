using System;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class BirthdayMessageTests
    {

        [Fact]
        public void Test()
        {
            DateTime today = new DateTime(16, 03, 1985);
            var john = TestEmployees.John.WasBorn(today);

            List<Employee> employees = new List<Employee>
            {
                john, TestEmployees.Mary
            };
            
            List<BirthdayMessage> expectedMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(john)
            };

            Assert.Equal(expectedMessages, BirthdayMessages.Of(employees));
        }

    }

    public class BirthdayMessage
    {
        private readonly Employee _employee;

        public BirthdayMessage(Employee employee)
        {
            _employee = employee;
        }
    }

    public static class BirthdayMessages
    {
        public static List<BirthdayMessage> Of(List<Employee> employees)
        {
            return new List<BirthdayMessage>();
        }
    }
}