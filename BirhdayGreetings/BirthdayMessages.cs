using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayGreetings
{
    public static class BirthdayMessages
    {
        public static List<BirthdayMessage> Of(List<Employee> employees, DateTime today) =>
            employees
                .Where(employee => employee.IsBirthday(today))
                .Select(employee => new BirthdayMessage(employee.Name))
                .ToList();

        public static List<BirthdayMessage> Of(List<Employee> employees) => Of(employees, DateTime.Now);

        public static List<BirthdayMessage> FromCsvFile(string filename, DateTime today)
        {
            List<Employee> employees = EmployeesCsvFileLoader.Load(filename);
            return BirthdayMessages.Of(employees, today);
        }

        public static List<BirthdayMessage> FromSqlLiteDb(string filename, DateTime today)
        {
            List<Employee> employees = EmployeesSqlLiteLoader.Load(filename);
            return BirthdayMessages.Of(employees, today);
        }
    }
}