using System.Collections.Generic;
using CustomerPreferenceCenter.Lib.Preferences;
namespace CustomerPreferenceCenter.Lib.CustomerPreferenceStores
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
