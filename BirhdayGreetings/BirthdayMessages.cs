using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayGreetings
{
    public class BirthdayMessages
    {
        private readonly IEmployeesRepository _employeesRepository;

        public static List<BirthdayMessage> Of(List<Employee> employees, DateTime today) =>
            employees
                .Where(employee => employee.IsBirthday(today))
                .Select(employee => new BirthdayMessage(employee.Name))
                .ToList();

        public static List<BirthdayMessage> Of(List<Employee> employees) => Of(employees, DateTime.Now);

        public static List<BirthdayMessage> FromCsvFile(string filename, DateTime today)
        {

            IEmployeesRepository employeesRepository = new CsvEmployeesRepository(filename);
            var birthdayMessages = new BirthdayMessages(employeesRepository);
            return birthdayMessages.CreateMessages(today);
        }

        public static List<BirthdayMessage> FromSqlLiteDb(string filename, DateTime today)
        {
            IEmployeesRepository employeesRepository = new SqlLiteEmployeesRepository(filename);
            var birthdayMessages = new BirthdayMessages(employeesRepository);
            return birthdayMessages.CreateMessages(today);
        }

        public BirthdayMessages(IEmployeesRepository employeesRepository)
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