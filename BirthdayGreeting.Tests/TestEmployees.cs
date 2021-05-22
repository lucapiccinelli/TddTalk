using System;

namespace BirthdayGreetings.Tests
{
    public static class TestEmployees
    {
        public static Employee John = new Employee("John", "Doe", new DateTime(1982, 10, 8), "john.doe@foobar.com");
        public static Employee Mary = new Employee("Mary", "Ann", new DateTime(1975, 9, 11), "mary.ann@foobar.com");

        public static Employee WasBorn(this Employee employee, DateTime birthday)
        {
            return new Employee(employee.Firstname, employee.Lastname, birthday, employee.Email);
        }
    }
}