namespace BirthdayGreetings.Domain.Model
{
    public class BirthdayMessage
    {
        private readonly Name _name;

        public BirthdayMessage(Name name)
        {
            _name = name;
        }

        protected bool Equals(BirthdayMessage other)
        {
            return Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BirthdayMessage) obj);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"{nameof(_name)}: {_name}";
        }
    }
}