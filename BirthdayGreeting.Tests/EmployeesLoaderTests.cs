using System;
using System.Collections.Generic;
using BirthdayGreetings.Exceptions;
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
                new Employee("John", "Doe", new DateTime(1982, 10, 8), "john.doe@foobar.com"),
                new Employee("Mary", "Ann", new DateTime(1975, 9, 11), "mary.ann@foobar.com")
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
