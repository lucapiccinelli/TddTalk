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

        public List<BirthdayMessage> CreateMessages(DateTime today)
        {
            List<Employee> employees = _employeesRepository.ReadAll();
            return BirthdayMessages.Of(employees, today);
        }

        public BirthdayMessages(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
    }

    public class CsvEmployeesRepository : IEmployeesRepository
    {
        private readonly string _filename;

        public CsvEmployeesRepository(string filename)
        {
            _filename = filename;
        }

        public List<Employee> ReadAll()
        {
            return EmployeesCsvFileLoader.Load(_filename);
        }
    }
}