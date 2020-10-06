using System.Collections.Generic;
using CustomerPreferenceCenter.Lib.Preferences;
namespace CustomerPreferenceCenter.Lib.CustomerPreferenceStores
{
    /// <summary>
    /// Represents a store for adding and retreiving Customer Preferences.
    /// </summary>
    public interface ICustomerPreferenceStore
    {
        IReadOnlyDictionary<Customer, IPreference> CustomerPreferences { get; }
        void AddCustomerPreference(Customer customer, IPreference preference);
    }
}
