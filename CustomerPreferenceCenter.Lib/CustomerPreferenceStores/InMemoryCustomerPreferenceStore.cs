using System.Collections.Generic;
using CustomerPreferenceCenter.Lib.Preferences;
namespace CustomerPreferenceCenter.Lib.CustomerPreferenceStores
{
    /// <summary>
    /// Holds Customer Preferences in memory for each instance.
    /// Data is NOT persisted between instances.
    /// </summary>
    public class InMemoryCustomerPreferenceStore : ICustomerPreferenceStore
    {
        private readonly IDictionary<string, IPreference> customerPreferences;
        public InMemoryCustomerPreferenceStore()
        {
            customerPreferences = new Dictionary<string, IPreference>();
        }

        public IReadOnlyDictionary<string, IPreference> CustomerPreferences
            => (IReadOnlyDictionary<string, IPreference>)customerPreferences;

        public void Add(string customer, IPreference preference)
        {
            if (customerPreferences.ContainsKey(customer))
                throw new CustomerPreferenceAlreadyExistsException(customer);
            customerPreferences.Add(customer, preference);
        }

        public void Remove(string customer) => customerPreferences.Remove(customer);
    }
}
