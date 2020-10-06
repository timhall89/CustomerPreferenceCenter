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
        private readonly IDictionary<Customer, IPreference> customerPreferences;
        public InMemoryCustomerPreferenceStore()
        {
            customerPreferences = new Dictionary<Customer, IPreference>();
        }

        public IReadOnlyDictionary<Customer, IPreference> CustomerPreferences => (IReadOnlyDictionary<Customer, IPreference>)customerPreferences;
        public void AddCustomerPreference(Customer customer, IPreference preference)
            => customerPreferences.Add(customer, preference);
    }
}
