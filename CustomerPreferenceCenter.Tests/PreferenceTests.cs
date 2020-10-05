using System;
using Xunit;
using Shouldly;
using CustomerPreferenceCenter.Lib.Preferences;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPreferenceCenter.Tests
{
    public class PreferenceTests
    {
        [Fact]
        public void Day_of_month_preference_determines_correct_result()
        {
            int preferenceDay = 5;
            IPreference preference = new DayOfMonthPreference(preferenceDay);
            for(int d = 1; d <= 28; d++)
            {
                if(d == preferenceDay)
                    preference.SendOnDate(new DateTime(2020, 1, d)).ShouldBeTrue($"Testing day {d} from preference {preferenceDay}");
                else
                    preference.SendOnDate(new DateTime(2020, 1, d)).ShouldBeFalse($"Testing day {d} from preference {preferenceDay}");
            }
        }

        [Fact]
        public void Day_of_month_preference_validates_the_contructor_arg()
        {
            IPreference preferenceLessThanLowerBound = new DayOfMonthPreference(-1);
            preferenceLessThanLowerBound.SendOnDate(new DateTime(2020, 1, 1)).ShouldBeTrue();
            IPreference preferenceGreaterThanUpperBound = new DayOfMonthPreference(40);
            preferenceGreaterThanUpperBound.SendOnDate(new DateTime(2020, 1, 28)).ShouldBeTrue();
        }

        [Fact]
        public void Days_of_week_preference_determines_correct_result()
        {
            IEnumerable<DayOfWeek> daysOfWeek = new DayOfWeek[] { DayOfWeek.Friday, DayOfWeek.Monday };
            IPreference preference = new DaysOfWeekPreference(daysOfWeek);
            for(int d = 4; d <= 10; d++)
            {
                DateTime date = new DateTime(2020, 10, d);
                if (daysOfWeek.Contains(date.DayOfWeek))
                    preference.SendOnDate(date).ShouldBeTrue($"Testing {date.DayOfWeek}");
                else
                    preference.SendOnDate(date).ShouldBeFalse($"Testing {date.DayOfWeek}");
            }
        }

        [Fact]
        public void Every_day_preference_determines_correct_result()
        {
            IPreference preference = new EveryDayPreference();
            for(int d = 1; d <= 31; d++)
            {
                DateTime date = new DateTime(2020, 1, d);
                preference.SendOnDate(date).ShouldBeTrue($"Testing {date:ddd dd/MM/yyyy}");
            }
        }

        [Fact]
        public void Never_preference_determines_correct_result()
        {
            IPreference preference = new NeverPreference();
            for (int d = 1; d <= 31; d++)
            {
                DateTime date = new DateTime(2020, 1, d);
                preference.SendOnDate(date).ShouldBeFalse($"Testing {date:ddd dd/MM/yyyy}");
            }
        }
    }
}
