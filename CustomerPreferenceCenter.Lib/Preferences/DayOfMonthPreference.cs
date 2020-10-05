using System;
namespace CustomerPreferenceCenter.Lib.Preferences
{
    public class DayOfMonthPreference : IPreference
    {
        private readonly int dayOfMonth;
        public DayOfMonthPreference(int dayOfMonth)
        {
            this.dayOfMonth = Math.Min(Math.Max(dayOfMonth, 1), 28);
        }

        public bool SendOnDate(DateTime date) => date.Day == dayOfMonth;
    }
}
