using System.Collections.Generic;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Domain.Doors
{
    public interface IEmployeesRepository
    {
        List<Employee> ReadAll();
    }
}