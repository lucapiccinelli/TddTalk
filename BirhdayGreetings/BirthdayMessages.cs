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
                .Select(employee => new BirthdayMessage(employee))
                .ToList();

        public static List<BirthdayMessage> Of(List<Employee> employees) => Of(employees, DateTime.Now);
    }
}