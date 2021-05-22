using System;
using System.Collections.Generic;
using BirthdayGreetings.Exceptions;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class EmployeesLoaderTests
    {
        [Fact]
        public void CanLoadEmployees_FromFile()
        {
            string filename = @"Resources\employees.txt";
            List<Employee> employees = EmployeesLoader.Load(filename);

            List<Employee> expectedEmployee = new List<Employee>
            {
                TestEmployees.John, TestEmployees.Mary
            };

            Assert.Equal(expectedEmployee, employees);
        }

        [Fact]
        public void AFile_InTheWrongFormat_ShouldThrow_AndTheException_ShouldContainTheList_OfErrors()
        {
            string filename = @"Resources\bad_format_employees.txt";

            var exception =  Assert.Throws<BadFormatException>(() => EmployeesLoader.Load(filename));
            Assert.Equal(2, exception.Errors.Count);
            Assert.Equal(1, exception.Errors[0].LineNumber);
        }
    }
}
