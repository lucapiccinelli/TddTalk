using System.Collections.Generic;

namespace BirthdayGreetings
{
    public class SqlLiteEmployeesRepository : IEmployeesRepository
    {
        private readonly string _filename;

        public SqlLiteEmployeesRepository(string filename)
        {
            _filename = filename;
        }

        public List<Employee> ReadAll()
        {
            return EmployeesSqlLiteLoader.Load(_filename);
        }
    }
}