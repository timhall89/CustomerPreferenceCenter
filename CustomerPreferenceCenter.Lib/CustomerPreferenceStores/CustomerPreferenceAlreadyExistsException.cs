using System;
namespace CustomerPreferenceCenter.Lib.CustomerPreferenceStores
{
    public class CustomerPreferenceAlreadyExistsException : Exception
    {
        public CustomerPreferenceAlreadyExistsException(string customer)
            : base($"A preference from a customer called {customer} already exists")
        {
        }
    }
}
