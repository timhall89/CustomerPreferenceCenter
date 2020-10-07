using System;
using System.Collections.Generic;
using CustomerPreferenceCenterLib.Preferences;
namespace CustomerPreferenceCenterLib.PreferenceCheckers
{
    public interface IPreferenceChecker
    {
        IReadOnlyDictionary<DateTime, ISet<string>> GetRecipientsForDateRange(DateTime startDate,
            int numOfDays, IReadOnlyDictionary<string, IPreference> customerPreferences);
    }
}
