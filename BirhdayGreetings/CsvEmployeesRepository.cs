using System.Collections.Generic;

namespace BirthdayGreetings
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