using System;

namespace BirthdayGreetings.Domain.Model
{
    public class Credentials
    {
        public string Username { get; }
        public string Password { get; }

        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return $"{nameof(Username)}: {Username}, {nameof(Password)}: {Password}";
        }

        protected bool Equals(Credentials other)
        {
            return Username == other.Username && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Credentials) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password);
        }
    }
}