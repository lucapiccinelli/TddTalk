using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Repositories.Csv
{
    public class CsvRepository : IRepository<Employee>
    {
        private readonly string _filename;

        public CsvRepository(string filename)
        {
            _filename = filename;
        }

        public List<Employee> ReadAll()
        {
            return EmployeesCsvFileLoader.Load(_filename);
        }

        public void New(Employee t) {}
    }
}