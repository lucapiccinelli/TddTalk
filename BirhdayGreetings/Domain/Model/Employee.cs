using System;

namespace BirthdayGreetings.Domain.Model
{
    public class Employee
    {
        private readonly DateTime _leapYearDateOfBirth;
        public EmailAddress EmailAddress { get; }
        public Name Name { get; }
        public DateTime DateOfBirth { get; }

        public Employee(string firstname, string lastname, DateTime dateOfBirth, string email)
        {
            EmailAddress = EmailAddress.Of(email);
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

        public Employee(Name name, in DateTime birthday, EmailAddress emailAddress) : this(name.Firstname, name.Lastname, birthday, emailAddress.Value)
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
            return Equals(EmailAddress, other.EmailAddress) && Equals(Name, other.Name) && DateOfBirth.Equals(other.DateOfBirth);
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
            return HashCode.Combine(EmailAddress, Name, DateOfBirth);
        }

        public override string ToString()
        {
            return $"{nameof(EmailAddress)}: {EmailAddress}, {nameof(Name)}: {Name}, {nameof(DateOfBirth)}: {DateOfBirth}";
        }
    }
}