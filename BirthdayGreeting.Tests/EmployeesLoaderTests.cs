using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;

namespace BirthdayGreetings.Tests
{
    // Happy path
    // File non esistente
    // Formato errato del file

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
    }

    public class EmployeesLoader
    {
        public static List<Employee> Load(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            string[] employeeLines = lines.Skip(1).ToArray();

            return employeeLines
                .Select(employeeLine => employeeLine.Split(",").Select(s => s.Trim()).ToArray())
                .Select(employeeTokens => new Employee(
                    employeeTokens[1],
                    employeeTokens[0],
                    DateTime.ParseExact(employeeTokens[2], "yyyy/MM/dd", CultureInfo.InvariantCulture),
                    employeeTokens[3]))
                .ToList();
        }
    }
}
