using System;

namespace BirthdayGreetings.Domain.Model
{
    public class EmailAddress
    {
        public static EmailAddress Of(string value)
        {
            return new EmailAddress(value);
        }

        public String Value { get; }

        private EmailAddress(string value)
        {
            Value = value;
        }

        protected bool Equals(EmailAddress other)
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
            return Equals((EmailAddress) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}