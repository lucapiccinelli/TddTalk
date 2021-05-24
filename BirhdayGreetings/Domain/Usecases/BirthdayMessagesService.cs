using System;
using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Repositories.Csv;
using BirthdayGreetings.Doors.Repositories.SqlLite;

namespace BirthdayGreetings.Domain.Usecases
{
    public class BirthdayMessagesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        public static List<BirthdayMessage> FromCsvFile(string filename, DateTime today)
        {
            IEmployeesRepository employeesRepository = new CsvEmployeesRepository(filename);
            var birthdayMessages = new BirthdayMessagesService(employeesRepository);
            return birthdayMessages.CreateMessages(today);
        }

        public static List<BirthdayMessage> FromSqlLiteDb(string filename, DateTime today)
        {
            IEmployeesRepository employeesRepository = new SqlLiteEmployeesRepository(filename);
            var birthdayMessages = new BirthdayMessagesService(employeesRepository);
            return birthdayMessages.CreateMessages(today);
        }

        public BirthdayMessagesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public List<BirthdayMessage> CreateMessages(DateTime today)
        {
            List<Employee> employees = _employeesRepository.ReadAll();
            return BirthdayMessages.Of(employees, today);
        }
    }
}