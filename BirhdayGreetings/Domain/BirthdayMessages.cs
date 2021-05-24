using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Domain
{
    public static class BirthdayMessages
    {
        public static List<BirthdayMessage> Of(List<Employee> employees, DateTime today) =>
            employees
                .Where(employee => employee.IsBirthday(today))
                .Select(employee => new BirthdayMessage(employee.Name))
                .ToList();
        public static List<BirthdayMessage> Of(List<Employee> employees) => Of(employees, DateTime.Now);
    }
}