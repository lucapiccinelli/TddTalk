using System;
using System.Globalization;
using System.Linq;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Repositories.Csv
{
    static public class EmployeesLineParser
    {
        public static Employee ParseLineToEmployee(string employeeLine)
        {
            string[] employeeTokens = ReadTokens(employeeLine);
            ValidateExpectedTokenNumber(employeeLine, employeeTokens, 4);
            ValidateNotEmptyTokens(employeeLine, employeeTokens);
            DateTime dateOfBirth = ValidateDate(employeeLine, employeeTokens[2]);

            return new Employee(
                firstname: employeeTokens[1],
                lastname: employeeTokens[0],
                dateOfBirth,
                email: employeeTokens[3]);
        }

        private static DateTime ValidateDate(string employeeLine, string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            catch(FormatException e)
            {
                throw new ArgumentException($"The date has an invalid format: {employeeLine}", e);
            }
        }

        private static void ValidateNotEmptyTokens(string employeeLine, string[] employeeTokens)
        {
            if (employeeTokens.Any(string.IsNullOrEmpty)) throw new ArgumentException($"Some information is missing on this line: {employeeLine}");
        }

        private static void ValidateExpectedTokenNumber(string employeeLine, string[] employeeTokens, int expectedTokens)
        {
            if (employeeTokens.Length < expectedTokens) throw new ArgumentException($"Some information is missing on this line: {employeeLine}");
        }

        private static string[] ReadTokens(string employeeLine)
        {
            return employeeLine.Split(",").Select(s => s.Trim()).ToArray();
        }
    }
}