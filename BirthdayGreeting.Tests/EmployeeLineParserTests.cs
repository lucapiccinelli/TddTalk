using System;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Domain;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Repositories.Csv;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class EmployeeLineParserTests
    {

        [Fact]
        public void Parsing_aLine_ReturnsAnEmployee()
        {
            string employeeLine = "Doe, John, 1982/10/08, john.doe@foobar.com";
            Employee employee = EmployeesLineParser.ParseLineToEmployee(employeeLine);
            var expectedEmployee = new Employee(
                "John", 
                "Doe", 
                new DateTime(1982, 10, 8), 
                "john.doe@foobar.com");

            Assert.Equal(expectedEmployee, employee);
        }

        [Theory]
        [InlineData("Doe, John, john.doe@foobar.com")]
        [InlineData("Doe, John,, john.doe@foobar.com")]
        [InlineData("Doe, John, banana, john.doe@foobar.com")]
        public void Parsing_aLine_NotWellFormatted_ThrowsAnArgumentException(string employeeLine)
        {
            Assert.Throws<ArgumentException>(() => EmployeesLineParser.ParseLineToEmployee(employeeLine));
        }

    }
}
