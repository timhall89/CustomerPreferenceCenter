using System;
using System.Collections.Generic;
namespace CustomerPreferenceCenter.Lib
{
    public class DaysOfWeekPreference : IPreference
    {
        private readonly ISet<DayOfWeek> daysOfWeek;
        public DaysOfWeekPreference(IEnumerable<DayOfWeek> daysOfWeek)
        {
            this.daysOfWeek = new HashSet<DayOfWeek>(daysOfWeek);
        }

        public bool SendOnDate(DateTime date) => daysOfWeek.Contains(date.DayOfWeek);
    }
}
