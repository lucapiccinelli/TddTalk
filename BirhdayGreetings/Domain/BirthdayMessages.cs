using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Domain.Usecases;
using BirthdayGreetings.Doors.Repositories.Csv;
using BirthdayGreetings.Doors.Repositories.SqlLite;

namespace BirthdayGreetings.Domain
{
    public static class BirthdayMessages
    {
        public static List<BirthdayMessage> FromCsvFile(string filename, DateTime today)
        {
            IRepository<Employee> repository = new CsvRepository(filename);
            var birthdayMessages = new BirthdayStoreService(repository);
            return birthdayMessages.CreateMessages(today);
        }

        public static List<BirthdayMessage> FromSqlLiteDb(string filename, DateTime today)
        {
            IRepository<Employee> repository = new SqlLiteRepository(filename);
            var birthdayMessages = new BirthdayStoreService(repository);
            return birthdayMessages.CreateMessages(today);
        }

        public static List<BirthdayMessage> Of(List<Employee> employees, DateTime today) =>
            employees
                .Where(employee => employee.IsBirthday(today))
                .Select(employee => new BirthdayMessage(employee.Name))
                .ToList();
        public static List<BirthdayMessage> Of(List<Employee> employees) => Of(employees, DateTime.Now);
    }
}