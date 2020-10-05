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

        public override string ToString() => $"{Id} - {FirstName} {LastName}";
    }
}
