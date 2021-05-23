using System;

namespace BirthdayGreetings
{
    public class Employee
    {
        private readonly DateTime _leapYearDateOfBirth;
        public Email Email { get; }
        public Name Name { get; }
        public DateTime DateOfBirth { get; }

        public Employee(string firstname, string lastname, DateTime dateOfBirth, string email)
        {
            Email = Email.Of(email);
            Name = new Name(firstname, lastname);
            DateOfBirth = dateOfBirth;
            _leapYearDateOfBirth = dateOfBirth;


            if (DateOfBirth.Day == 29 && DateOfBirth.Month == 2)
            {
                _leapYearDateOfBirth = new DateTime(dateOfBirth.Year, dateOfBirth.Month, 28);
            }
        }

        public Employee(Name name, in DateTime birthday, string email) : this(name.Firstname, name.Lastname, birthday, email)
        {
        }

        public Employee(Name name, in DateTime birthday, Email email) : this(name.Firstname, name.Lastname, birthday, email.Value)
        {
        }

        public bool IsBirthday(DateTime today)
        {
            if (today.Day != 28 || today.Month != 2 || DateTime.IsLeapYear(today.Year))
            {
                return MatchDate(today, DateOfBirth);
            }

            return MatchDate(today, _leapYearDateOfBirth);
        }

        private bool MatchDate(DateTime today, DateTime dateOfBirth) =>
            dateOfBirth.Date.Month == today.Date.Month &&
            dateOfBirth.Date.Day == today.Date.Day &&
            dateOfBirth.Date.Year <= today.Year;

        protected bool Equals(Employee other)
        {
            return Equals(Email, other.Email) && Equals(Name, other.Name) && DateOfBirth.Equals(other.DateOfBirth);
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
            return HashCode.Combine(Email, Name, DateOfBirth);
        }

        public override string ToString()
        {
            return $"{nameof(Email)}: {Email}, {nameof(Name)}: {Name}, {nameof(DateOfBirth)}: {DateOfBirth}";
        }
    }
}