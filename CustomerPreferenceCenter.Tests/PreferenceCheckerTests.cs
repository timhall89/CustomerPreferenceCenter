using System;
using Xunit;
using Shouldly;
using CustomerPreferenceCenter.Lib;
using System.Collections.Generic;
using System.Linq;
namespace CustomerPreferenceCenter.Tests
{
    public class PreferenceCheckerTests
    {
        [Fact]
        public void Preference_checker_checks_correctly()
        {
            IDictionary<Customer, IPreference> customerPreferences = new Dictionary<Customer, IPreference>
            {
                {new Customer(1, "John", "Doe"), new NeverPreference() },
                {new Customer(2, "Jane", "Doe"), new EveryDayPreference() },
                {new Customer(3, "Jessie", "Doe"), new DayOfMonthPreference(4) },
                {new Customer(4, "Joe", "Doe"), new DayOfMonthPreference(10) },
                {new Customer(5, "Julie", "Doe"), new DaysOfWeekPreference(new DayOfWeek[]{ DayOfWeek.Monday}) },
                {new Customer(6, "Jason", "Doe"), new DaysOfWeekPreference(new DayOfWeek[]{ DayOfWeek.Monday, DayOfWeek.Thursday}) },
            };

            PreferenceChecker preferenceChecker = new PreferenceChecker();
            DateTime startDate = new DateTime(2020, 10, 4);
            int numOfDays = 7;

            IDictionary<DateTime, ISet<Customer>> recipientsForDates =
                preferenceChecker.GetRecipientsForDateRange(startDate, numOfDays, customerPreferences);

            recipientsForDates.Count.ShouldBe(7);


            IDictionary<DateTime, ISet<Customer>> expectedResults = new Dictionary<DateTime, ISet<Customer>>
            {
                {
                    new DateTime(2020, 10, 4),
                    new HashSet<Customer>
                    {
                        new Customer(2, "Jane", "Doe"),
                        new Customer(3, "Jessie", "Doe")
                    }
                },
                {
                    new DateTime(2020, 10, 5), new HashSet<Customer>
                    {
                        new Customer(2, "Jane", "Doe"),
                        new Customer(5, "Julie", "Doe"),
                        new Customer(6, "Jason", "Doe")
                    }
                },
                {
                    new DateTime(2020, 10, 6),
                    new HashSet<Customer>
                    {
                        new Customer(2, "Jane", "Doe")
                    }
                },
                {
                    new DateTime(2020, 10, 7),
                    new HashSet<Customer>
                    {
                        new Customer(2, "Jane", "Doe")
                    }
                },
                {
                    new DateTime(2020, 10, 8),
                    new HashSet<Customer>
                    {
                        new Customer(2, "Jane", "Doe"),
                        new Customer(6, "Jason", "Doe")
                    }
                },
                {
                    new DateTime(2020, 10, 9),
                    new HashSet<Customer>
                    {
                        new Customer(2, "Jane", "Doe")
                    }
                },
                {
                    new DateTime(2020, 10, 10),
                    new HashSet<Customer>
                    {
                        new Customer(2, "Jane", "Doe"),
                        new Customer(4, "Joe", "Doe")
                    }
                },
            };

            foreach(KeyValuePair<DateTime, ISet<Customer>> recipientsForDate in recipientsForDates)
            {
                recipientsForDate.Value.SetEquals(expectedResults[recipientsForDate.Key])
                    .ShouldBeTrue($"Testing {recipientsForDate.Key:ddd dd/MM/yyyy}");
            }

        }
    }
}
