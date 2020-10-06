using System;
using System.Collections.Generic;
using CustomerPreferenceCenter.Lib.Preferences;

namespace CustomerPreferenceCenter.Lib.CustomerPreferenceStores
{
    /// <summary>
    /// This Class is NOT implemented but it represents how a Customer
    /// Preference Store that would persist data to a Database.
    /// </summary>
    public class DatabaseCustomerPreferenceStore : ICustomerPreferenceStore
    {
        public IReadOnlyDictionary<Customer, IPreference> CustomerPreferences
            => throw new NotImplementedException();

        public void Add(Customer customer, IPreference preference)
            => throw new NotImplementedException();
        
        public void Remove(Customer customer)
            => throw new NotImplementedException();
    }
}
