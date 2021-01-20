using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BirthdayGreetings
{
    public class EmployeesLoader
    {
        public static List<Employee> Load(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            string[] employeeLines = SkipHeader(lines);

            return employeeLines
                .Select(ParseLineToEmployee)
                .ToList();
        }

        private static Employee ParseLineToEmployee(string employeeLine)
        {
            string[] employeeTokens = employeeLine.Split(",").Select(s => s.Trim()).ToArray();
            return new Employee(
                employeeTokens[1],
                employeeTokens[0],
                DateTime.ParseExact(employeeTokens[2], "yyyy/MM/dd", CultureInfo.InvariantCulture),
                employeeTokens[3]);
        }

        private static string[] SkipHeader(string[] lines)
        {
            return lines.Skip(1).ToArray();
        }
    }
}