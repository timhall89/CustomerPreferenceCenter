using System;
using CustomerPreferenceCenterLib.PreferenceCheckers;
using CustomerPreferenceCenterLib.CustomerPreferenceStores;
using CustomerPreferenceCenterLib.Preferences;
using static CustomerPreferenceCenterConsole.ConsoleReaderAndWriter;
namespace CustomerPreferenceCenterConsole
{
    class Program
    {
        private readonly ICustomerPreferenceStore customerPreferenceStore;
        private readonly IPreferenceChecker preferenceChecker;

        static void Main()
        {
            Program program = new Program(new InMemoryCustomerPreferenceStore(), new PreferenceChecker());
            program.Run();
        }

        public Program(ICustomerPreferenceStore customerPreferenceStore, IPreferenceChecker preferenceChecker)
        {
            this.customerPreferenceStore = customerPreferenceStore;
            this.preferenceChecker = preferenceChecker;
        }

        private void Run()
        {
            WriteTitle();
            ListCommands();
            try
            {
                while (true) ReadConsoleInput(RunCommand, "Type a command and hit enter...");
            }
            catch (OperationCanceledException)
            {
                _("Exiting application...");
            }
        }

        private void RunCommand(string command)
        {
            switch (command.ToUpper())
            {
                case Options.ADD_NEW_CUSTOMER_PREFERENCE:
                    AddNewCustomerPreference();
                    break;
                case Options.DELETE_CUSTOMER_PREFERENCE:
                    DeleteCustomerPreference();
                    break;
                case Options.LIST_COSTOMER_PREFERENCES:
                    if (customerPreferenceStore.CustomerPreferences.Count < 1)
                        _("-- No Preferences --");
                    foreach (var customerPreference in customerPreferenceStore.CustomerPreferences)
                    {
                        _($"[{customerPreference.Key}] => [{customerPreference.Value}]");
                    }
                    break;
                case Options.REPORT_RECIPIENTS_FOR_DATE_RANGE:
                    ListRecipientsOnDates();
                    break;
                case Options.LIST_OPTIONS:
                    ListCommands();
                    break;
                default:
                    throw new FormatException("Command not recognised, please try again or enter H to see a list of possible commands.");
            }
        }

        private void DeleteCustomerPreference()
        {
            _("Deleteing customer preference");
            try
            {
                ReadConsoleInput(name =>
                {
                    if(!customerPreferenceStore.CustomerPreferences.ContainsKey(name))
                        throw new FormatException($"No preference for customer {name}, please try again");
                    customerPreferenceStore.Remove(name);
                }, "Enter name of customer");

                _("Customer preference deleted");
            }
            catch (OperationCanceledException)
            {
                _("Deleting customer preference cancelled");
            }
        }

        private void ListRecipientsOnDates()
        {
            _("Listing recipients on dates");
            try
            {
                int numOfDays = ReadConsoleInput(input =>
                {
                    if (!int.TryParse(input, out int num) || num < 1 || num > 365)
                        throw new FormatException("Input must be a valid integer between 1 and 365, please try again");

                    return num;
                }, "Enter number of days to view");

                foreach (var x in preferenceChecker.GetRecipientsForDateRange(DateTime.Today, numOfDays, customerPreferenceStore.CustomerPreferences))
                {
                    _($"{x.Key:ddd dd/MM/yyyy} | {string.Join(", ", x.Value)}");
                }
            }
            catch (OperationCanceledException)
            {
                _("Listing recipients cancelled");
            }
        }

        private void AddNewCustomerPreference()
        {
            _("-- Adding new Customer preference --");
            try
            {
                string customer = GetCustomer();
                IPreference preference = GetPreference();
                customerPreferenceStore.Add(customer, preference);
                _($"*** Created new customer Preference : [{customer}] => [{preference}]");
            }
            catch (OperationCanceledException)
            {
                _("Adding new customer preference process was exited with out being completed");
            }
        }

        private string GetCustomer()
            => ReadConsoleInput(name =>
            {
                if (customerPreferenceStore.CustomerPreferences.ContainsKey(name))
                    throw new FormatException($"A preference for {name} already exists, please enter a different name or exit this wizard and delete the preference for {name}");

                return name;
            }, "Enter the customer Name");

        private IPreference GetPreference()
        {
            ListPreferenceOptions();
            return ReadConsoleInput(GetPreference);
        }

        private IPreference GetPreference(string option)
        {
            IPreference preference;
            switch (option.ToUpper())
            {
                case Options.EVERY_DAY_PREFERENCE:
                    preference = new EveryDayPreference();
                    break;
                case Options.NEVER_PREFERENCE:
                    preference = new NeverPreference();
                    break;
                case Options.DAY_OF_MONTH_PREFERENCE:
                    string dayOfMonthMessage = "Enter the day of month (1 - 28), Any number less than 1 will be taken as 1 and any number greater than 28 will be taken as 28";
                    preference = ReadConsoleInput(DayOfMonthPreference.Parse, dayOfMonthMessage);
                    break;
                case Options.DAYS_OF_WEEK_PREFERENCE:
                    _(@"Enter a comma separated list of one or more weekday numbers, from 1 = Sunday to 7 = Saturday, example ""1,4,5""");
                    _("if any values are not a number between 1 and 7 the whole input will fail");
                    preference = ReadConsoleInput(DaysOfWeekPreference.Parse);
                    break;
                default:
                    throw new FormatException($"Option {option} is not valid, please try again");

            }

            return preference;
        }
    }
}
