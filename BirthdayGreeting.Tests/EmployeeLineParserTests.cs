﻿using System;
using System.Collections.Generic;
using System.Text;
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

    }
}
