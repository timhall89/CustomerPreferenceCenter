using System;
namespace CustomerPreferenceCenter.Lib.CustomerPreferenceStores
{
    public class CustomerPreferenceAlreadyExistsException : Exception
    {
        public CustomerPreferenceAlreadyExistsException(Customer customer)
            : base($"A custoemr with id {customer.Id} already exists")
        {
        }
    }
}
