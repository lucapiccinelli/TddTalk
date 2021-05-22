using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class BirthdaysTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new DateTime(1984, 3, 16), new DateTime(1985, 3, 16), true};
            yield return new object[] {new DateTime(1984, 3, 16), new DateTime(1983, 3, 16), false};
            yield return new object[] {new DateTime(1985, 3, 17), new DateTime(1985, 3, 16), false};
            yield return new object[] {new DateTime(1985, 3, 28), new DateTime(2012, 3, 28), true};
            yield return new object[] {new DateTime(1985, 2, 28), new DateTime(1985, 2, 28), true};
            yield return new object[] {new DateTime(2012, 2, 29), new DateTime(2016, 2, 29), true};
            yield return new object[] {new DateTime(2012, 2, 29), new DateTime(2016, 2, 28), false};
            yield return new object[] {new DateTime(2012, 2, 29), new DateTime(2017, 2, 28), true};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class BirthDayTests
    {

        [Theory]
        [ClassData(typeof(BirthdaysTestData))]
        public void IsBirthday(DateTime birthday, DateTime today, bool expected)
        {
            Employee john = TestEmployees.John.WasBorn(birthday);
            Assert.Equal(expected, john.IsBirthday(today));
        }

    }
}
