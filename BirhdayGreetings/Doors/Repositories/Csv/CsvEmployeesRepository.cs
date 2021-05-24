using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Repositories.Csv
{
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