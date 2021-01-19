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

        protected bool Equals(Employee other)
        {
            return Email == other.Email && Firstname == other.Firstname && Lastname == other.Lastname && DateOfBirth.Equals(other.DateOfBirth);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Employee) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, Firstname, Lastname, DateOfBirth);
        }
    }
}