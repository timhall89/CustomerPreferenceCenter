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

        public override string ToString() => $"Day of month: {dayOfMonth}";

        public override int GetHashCode() => dayOfMonth;
        public override bool Equals(object obj)
            => obj is DayOfMonthPreference dayOfMonthPreference && dayOfMonthPreference.GetHashCode() == GetHashCode();

        /// <summary>
        /// Parses a new DayOfMonthPreference instance from a string in the format of an integer.
        /// </summary>
        public static DayOfMonthPreference Parse(string dayOfMonthStr)
        {
            if (!int.TryParse(dayOfMonthStr, out int dayOfMonth))
                throw new FormatException("day of month entered was not a valid integer, please try again");
            return new DayOfMonthPreference(dayOfMonth);
        }
    }
}
