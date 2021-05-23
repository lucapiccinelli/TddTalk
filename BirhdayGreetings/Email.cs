using System;

namespace BirthdayGreetings
{
    public class Email
    {
        public static Email Of(string value)
        {
            return new Email(value);
        }

        public String Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        protected bool Equals(Email other)
        {
            return Value == other.Value;
        }

        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Email) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}