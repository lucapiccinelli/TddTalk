using System;
using System.Globalization;
using System.Linq;

namespace BirthdayGreetings
{
    static public class EmployeesLineParser
    {
        public static Employee ParseLineToEmployee(string employeeLine)
        {
            string[] employeeTokens = employeeLine.Split(",").Select(s => s.Trim()).ToArray();
            if(employeeTokens.Length < 4) throw new ArgumentException($"Some information is missing on this line: {employeeLine}");
            if(employeeTokens.Any(string.IsNullOrEmpty)) throw new ArgumentException($"Some information is missing on this line: {employeeLine}");
            try
            {
                return new Employee(
                    employeeTokens[1],
                    employeeTokens[0],
                    DateTime.ParseExact(employeeTokens[2], "yyyy/MM/dd", CultureInfo.InvariantCulture),
                    employeeTokens[3]);
            }
            catch (FormatException e)
            {
                throw new ArgumentException($"The date has an invalid format: {employeeLine}", e);
            }
        }
    }
}