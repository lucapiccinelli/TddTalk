using System;

namespace BirthdayGreetings.Domain.Model
{
    public class Name
    {
        public string Firstname { get; }
        public string Lastname { get; }

        public Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        protected bool Equals(Name other)
        {
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Name) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Firstname, Lastname);
        }

        public override string ToString()
        {
            return $"{nameof(Firstname)}: {Firstname}, {nameof(Lastname)}: {Lastname}";
        }
    }
}