using System;
using System.Collections.Generic;
using System.Linq;
using CustomerPreferenceCenterLib.Preferences;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace CustomerPreferenceCenterLib.PreferenceCheckers
{
    public class ParallelPreferenceChecker : IPreferenceChecker
    {
        public IReadOnlyDictionary<DateTime, ISet<string>> GetRecipientsForDateRange(DateTime startDate,
            int numOfDays, IReadOnlyDictionary<string, IPreference> customerPreferences)
        {
            ConcurrentDictionary<DateTime, ISet<string>> recipientsForDates = new ConcurrentDictionary<DateTime, ISet<string>>(10, numOfDays);
            List<Task> tasks = new List<Task>(numOfDays);
            DateTime endDate = startDate.AddDays(numOfDays - 1);

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DateTime _date = date;
                if (recipientsForDates.TryAdd(_date, null))
                {
                    Task t = Task.Run(() =>
                    {
                        IEnumerable<string> customers = customerPreferences
                        .Where(customerPreference => customerPreference.Value.SendOnDate(_date))
                        .Select(customerPreference => customerPreference.Key);

                        recipientsForDates.TryUpdate(_date, new HashSet<string>(customers), null);
                    });

                    tasks.Add(t);
                };
               
            }
            Task.WaitAll(tasks.ToArray());
            return recipientsForDates;
        }
    }
}
