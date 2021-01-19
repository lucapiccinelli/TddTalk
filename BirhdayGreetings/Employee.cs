using System;

namespace BirthdayGreetings
{
    public class Employee
    {
        public string Email { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public DateTime DateOfBirth { get; }

        public Employee(string firstname, string lastname, DateTime dateOfBirth, string email)
        {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }
    }
}