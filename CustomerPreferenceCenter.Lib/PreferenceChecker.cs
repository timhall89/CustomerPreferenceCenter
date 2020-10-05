using System;
using System.Collections.Generic;
using System.Linq;
using CustomerPreferenceCenter.Lib.Preferences;

namespace CustomerPreferenceCenter.Lib
{
    public class PreferenceChecker
    {
        public IDictionary<DateTime, ISet<Customer>> GetRecipientsForDateRange(DateTime startDate,
            int numOfDays, IDictionary<Customer, IPreference> customerPreferences)
        {
            IDictionary<DateTime, ISet<Customer>> recipientsForDates = new Dictionary<DateTime, ISet<Customer>>();

            DateTime endDate = startDate.AddDays(numOfDays - 1);

            for(DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                IEnumerable<Customer> customers = customerPreferences
                    .Where(customerPreference => customerPreference.Value.SendOnDate(date))
                    .Select(customerPreference => customerPreference.Key);

                recipientsForDates.Add(date, new HashSet<Customer>(customers));
            }

            return recipientsForDates;
        }
    }
}
