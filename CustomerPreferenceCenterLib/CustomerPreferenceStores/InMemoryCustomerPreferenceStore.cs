using System;
using System.Collections.Generic;
using CustomerPreferenceCenterLib.Preferences;
namespace CustomerPreferenceCenterLib.CustomerPreferenceStores
{
    /// <summary>
    /// Holds Customer Preferences in memory for each instance.
    /// Data is NOT persisted between instances.
    /// </summary>
    public class InMemoryCustomerPreferenceStore : ICustomerPreferenceStore
    {
        private readonly Dictionary<string, IPreference> customerPreferences;
        public InMemoryCustomerPreferenceStore()
        {
            customerPreferences = new Dictionary<string, IPreference>();
        }

        public IReadOnlyDictionary<string, IPreference> CustomerPreferences
            => customerPreferences;

        public void Add(string customer, IPreference preference)
        {
            if (!customerPreferences.TryAdd(customer, preference))
                throw new InvalidOperationException($"A preference for {customer} already exists");
        }

        public void Remove(string customer) => customerPreferences.Remove(customer);
    }
}
