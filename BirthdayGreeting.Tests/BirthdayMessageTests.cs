using System;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class BirthdayMessageTests
    {

        [Fact]
        public void CreateBirthdayMessages()
        {
            DateTime today = new DateTime(1985, 03, 16);
            var john = TestEmployees.John.WasBorn(today);

            List<Employee> employees = new List<Employee>
            {
                john, TestEmployees.Mary
            };
            
            List<BirthdayMessage> expectedMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(john)
            };

            Assert.Equal(expectedMessages, BirthdayMessages.Of(employees, today));
        }

    }
}