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
            return new Employee(
                employeeTokens[1],
                employeeTokens[0],
                DateTime.ParseExact(employeeTokens[2], "yyyy/MM/dd", CultureInfo.InvariantCulture),
                employeeTokens[3]);
        }
    }
}