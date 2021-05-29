namespace BirthdayGreetings.Domain.Model
{
    public class BirthdayMessage
    {
        public Name Name { get; }

        public BirthdayMessage(Name name)
        {
            Name = name;
        }

        protected bool Equals(BirthdayMessage other)
        {
            return Equals(Name, other.Name);
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
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"Happy birthday dear {Name.Firstname} {Name.Lastname}";
        }
    }
}