using System;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class SqlLiteEmployeesLoaderTests
    {
        [Fact]
        public void CanRead_AListOfEmployees_FromSqlLite()
        {
            string filename = @"Resources\employees.db";
            List<Employee> employees = EmployeesSqlLiteLoader.Load(filename);

            List<Employee> expectedEmployee = new List<Employee>
            {
                TestEmployees.John, TestEmployees.Mary
            };

            Assert.Equal(expectedEmployee, employees);
        }
    }
}
