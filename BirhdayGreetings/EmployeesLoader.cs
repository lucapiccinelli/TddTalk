using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BirthdayGreetings.Exceptions;

namespace BirthdayGreetings
{
    public class EmployeesLoader
    {
        public static List<Employee> Load(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            string[] employeeLines = SkipHeader(lines);
            var employees = ParseEmployees(employeeLines);

            return employees;
        }

        private static List<Employee> ParseEmployees(string[] employeeLines)
        {
            List<Employee> employees = new List<Employee>();
            List<ParsingError> errors = new List<ParsingError>();
            for (var i = 0; i < employeeLines.Length; i++)
            {
                var employeeLine = employeeLines[i];
                try
                {
                    Employee employee = EmployeesLineParser.ParseLineToEmployee(employeeLine);
                    employees.Add(employee);
                }
                catch (ArgumentException e)
                {
                    errors.Add(new ParsingError(i + 1, e));
                }
            }

            if (errors.Count > 0) throw new BadFormatException(errors);
            return employees;
        }

        private static string[] SkipHeader(string[] lines) => lines.Skip(1).ToArray();
    }
}