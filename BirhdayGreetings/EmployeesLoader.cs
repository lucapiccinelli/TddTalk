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
                .Select(EmployeesLineParser.ParseLineToEmployee)
                .ToList();
        }

        private static string[] SkipHeader(string[] lines) => lines.Skip(1).ToArray();
    }
}