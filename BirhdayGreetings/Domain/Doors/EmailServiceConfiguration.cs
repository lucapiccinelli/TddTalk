using System;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Email;

namespace BirthdayGreetings.Domain.Doors
{
    public class EmailServiceConfiguration
    {
        public bool Ssl { get; set; }
        public string Smtp { get; set; }
        public int Port { get; set; }
        public Credentials Credentials { get; set; }

        public override string ToString()
        {
            return $"{nameof(Ssl)}: {Ssl}, {nameof(Smtp)}: {Smtp}, {nameof(Port)}: {Port}, {nameof(Credentials)}: {Credentials}";
        }

        protected bool Equals(EmailServiceConfiguration other)
        {
            return Ssl == other.Ssl && Smtp == other.Smtp && Port == other.Port && Equals(Credentials, other.Credentials);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EmailServiceConfiguration) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ssl, Smtp, Port, Credentials);
        }
    }
}