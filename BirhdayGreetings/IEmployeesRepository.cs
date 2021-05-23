using System.Collections.Generic;

namespace BirthdayGreetings
{
    public interface IEmployeesRepository
    {
        List<Employee> ReadAll();
    }
}