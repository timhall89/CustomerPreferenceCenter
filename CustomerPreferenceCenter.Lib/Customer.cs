namespace CustomerPreferenceCenter.Lib
{
    public class Customer
    {
        public Customer(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public override int GetHashCode() => Id;
        public override bool Equals(object obj)
            => obj is Customer customer && customer.GetHashCode() == GetHashCode();

        public override string ToString() => $"{Id} - {FirstName} {LastName}";
    }
}
