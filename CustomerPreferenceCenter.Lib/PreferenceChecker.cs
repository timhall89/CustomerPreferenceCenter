using System;
using System.Collections.Generic;
using System.Linq;
using CustomerPreferenceCenter.Lib.Preferences;

namespace CustomerPreferenceCenter.Lib
{
    public class PreferenceChecker
    {
        public IReadOnlyDictionary<DateTime, ISet<string>> GetRecipientsForDateRange(DateTime startDate,
            int numOfDays, IReadOnlyDictionary<string, IPreference> customerPreferences)
        {
            IDictionary<DateTime, ISet<string>> recipientsForDates = new Dictionary<DateTime, ISet<string>>();

            DateTime endDate = startDate.AddDays(numOfDays - 1);

            for(DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                IEnumerable<string> customers = customerPreferences
                    .Where(customerPreference => customerPreference.Value.SendOnDate(date))
                    .Select(customerPreference => customerPreference.Key);

                recipientsForDates.Add(date, new HashSet<string>(customers));
            }

            return (IReadOnlyDictionary < DateTime, ISet<string> > )recipientsForDates;
        }
    }
}
