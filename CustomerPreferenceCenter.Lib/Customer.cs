namespace CustomerPreferenceCenter.Lib
{
    public class Customer
    {
        public Customer(int id, string name = null)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public override int GetHashCode() => Id;
        public override bool Equals(object obj)
            => obj is Customer customer && customer.GetHashCode() == GetHashCode();

        public override string ToString() => $"{Id} - {Name}";
    }
}
