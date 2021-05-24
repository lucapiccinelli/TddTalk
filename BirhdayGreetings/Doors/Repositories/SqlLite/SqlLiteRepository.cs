using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Repositories.SqlLite
{
    public class SqlLiteRepository : IRepository<Employee>
    {
        private readonly string _filename;

        public SqlLiteRepository(string filename)
        {
            _filename = filename;
        }

        public List<Employee> ReadAll()
        {
            return EmployeesSqlLiteLoader.Load(_filename);
        }

        public void New(Employee t) {}
    }
}