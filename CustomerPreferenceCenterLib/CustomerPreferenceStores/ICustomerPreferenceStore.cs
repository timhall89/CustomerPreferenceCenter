using System.Collections.Generic;
using CustomerPreferenceCenterLib.Preferences;
namespace CustomerPreferenceCenterLib.CustomerPreferenceStores
{
    /// <summary>
    /// Represents a store for adding and retreiving Customer Preferences.
    /// </summary>
    public interface ICustomerPreferenceStore
    {
        IReadOnlyDictionary<string, IPreference> CustomerPreferences { get; }
        void Add(string customer, IPreference preference);
        void Remove(string customer);
    }
}
