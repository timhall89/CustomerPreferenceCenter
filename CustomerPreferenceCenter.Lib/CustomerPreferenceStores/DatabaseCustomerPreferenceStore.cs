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
        public IReadOnlyDictionary<string, IPreference> CustomerPreferences
            => throw new NotImplementedException();

        public void Add(string customer, IPreference preference)
            => throw new NotImplementedException();
        
        public void Remove(string customer)
            => throw new NotImplementedException();
    }
}
