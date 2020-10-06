using System;
using System.Collections.Generic;
namespace CustomerPreferenceCenterLib.Preferences
{
    public class DaysOfWeekPreference : IPreference
    {
        private readonly ISet<DayOfWeek> daysOfWeek;
        public DaysOfWeekPreference(IEnumerable<DayOfWeek> daysOfWeek)
        {
            this.daysOfWeek = new HashSet<DayOfWeek>(daysOfWeek);
        }

        public bool SendOnDate(DateTime date) => daysOfWeek.Contains(date.DayOfWeek);

        public override string ToString() => string.Join(", ", daysOfWeek);

        /// <summary>
        /// Parses a new instance of DaysOfWeekPreference
        /// from a string of comma separated integer between 1 and 7.
        /// </summary>
        public static DaysOfWeekPreference Parse(string daysOfWeekStr)
        {
            string[] daysOfWeekStrArray = daysOfWeekStr.Split(',');
            if (daysOfWeekStrArray.Length < 1) throw new FormatException("No days of week have been given");
            try
            {
                DayOfWeek[] daysOfWeek = new DayOfWeek[daysOfWeekStrArray.Length];
                for (int i = 0; i < daysOfWeek.Length; i++)
                {
                    int dayOfWeek = int.Parse(daysOfWeekStrArray[i]);
                    if (dayOfWeek < 1 || dayOfWeek > 7) throw new ArgumentOutOfRangeException();
                    daysOfWeek[i] = (DayOfWeek)(dayOfWeek - 1);
                }

                return new DaysOfWeekPreference(daysOfWeek);
            }
            catch (Exception)
            {
                throw new FormatException("One of more of the comma separated inputs is not valid, please try again");
            }
        }
    }
}
