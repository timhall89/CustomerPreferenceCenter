using System;
using Xunit;
using Shouldly;
using CustomerPreferenceCenterLib.Preferences;
using CustomerPreferenceCenterLib.PreferenceCheckers;
using System.Collections.Generic;
namespace CustomerPreferenceCenterLib.Tests
{
    public class PreferenceCheckerTests
    {
        [Fact]
        public void Preference_checker_checks_correctly()
        {
            IReadOnlyDictionary<string, IPreference> customerPreferences = new Dictionary<string, IPreference>
            {
                {"John Doe", new NeverPreference() },
                {"Jane Doe", new EveryDayPreference() },
                {"Jessie Doe", new DayOfMonthPreference(4) },
                {"Joe Doe", new DayOfMonthPreference(10) },
                {"Julie Doe", new DaysOfWeekPreference(new DayOfWeek[]{ DayOfWeek.Monday}) },
                {"Jason Doe", new DaysOfWeekPreference(new DayOfWeek[]{ DayOfWeek.Monday, DayOfWeek.Thursday}) },
            };

            IPreferenceChecker preferenceChecker = new PreferenceChecker();
            DateTime startDate = new DateTime(2020, 10, 4);
            int numOfDays = 7;

            IReadOnlyDictionary<DateTime, ISet<string>> recipientsForDates =
                preferenceChecker.GetRecipientsForDateRange(startDate, numOfDays, customerPreferences);

            recipientsForDates.Count.ShouldBe(7);


            IDictionary<DateTime, ISet<string>> expectedResults = new Dictionary<DateTime, ISet<string>>
            {
                {
                    new DateTime(2020, 10, 4),
                    new HashSet<string>
                    {
                        "Jane Doe",
                        "Jessie Doe"
                    }
                },
                {
                    new DateTime(2020, 10, 5), new HashSet<string>
                    {
                        "Jane Doe",
                        "Julie Doe",
                        "Jason Doe"
                    }
                },
                {
                    new DateTime(2020, 10, 6),
                    new HashSet<string>
                    {
                        "Jane Doe"
                    }
                },
                {
                    new DateTime(2020, 10, 7),
                    new HashSet<string>
                    {
                        "Jane Doe"
                    }
                },
                {
                    new DateTime(2020, 10, 8),
                    new HashSet<string>
                    {
                        "Jane Doe",
                        "Jason Doe"
                    }
                },
                {
                    new DateTime(2020, 10, 9),
                    new HashSet<string>
                    {
                        "Jane Doe"
                    }
                },
                {
                    new DateTime(2020, 10, 10),
                    new HashSet<string>
                    {
                        "Jane Doe",
                        "Joe Doe"
                    }
                },
            };

            foreach(KeyValuePair<DateTime, ISet<string>> recipientsForDate in recipientsForDates)
            {
                recipientsForDate.Value.SetEquals(expectedResults[recipientsForDate.Key])
                    .ShouldBeTrue($"Testing {recipientsForDate.Key:ddd dd/MM/yyyy}");
            }

        }
    }
}
