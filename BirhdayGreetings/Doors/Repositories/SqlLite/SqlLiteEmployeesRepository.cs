using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Repositories.SqlLite
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