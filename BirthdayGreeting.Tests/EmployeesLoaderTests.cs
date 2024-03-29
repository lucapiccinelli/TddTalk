﻿using System;
using System.Collections.Generic;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Repositories.Csv;
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
            List<Employee> employees = EmployeesCsvFileLoader.Load(filename);

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

            var exception =  Assert.Throws<BadFormatException>(() => EmployeesCsvFileLoader.Load(filename));
            Assert.Equal(2, exception.Errors.Count);
            Assert.Equal(1, exception.Errors[0].LineNumber);
            Assert.Equal(2, exception.Errors[1].LineNumber);
        }
    }
}
