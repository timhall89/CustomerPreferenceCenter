using System;
namespace CustomerPreferenceCenterConsole
{
    public static class ConsoleReaderAndWriter
    {
        public static void _(string s) => Console.WriteLine(s);
        public static void Warn(string s) => Console.WriteLine($"WARNING: {s}");

        public static T ReadConsoleInput<T>(Func<string, T> convert, string msg = null)
        {
            while (true)
            {
                try
                {
                    return convert(ReadConsoleInput(msg));
                }
                catch (FormatException ex)
                {
                    Warn(ex.Message);
                }
            }
        }

        public static void ReadConsoleInput(Action<string> callBack, string msg = null)
        {
            while (true)
            {
                try
                {
                    callBack(ReadConsoleInput(msg));
                    return;
                }
                catch (FormatException ex)
                {
                    Warn(ex.Message);
                }
            }
        }

        public static string ReadConsoleInput(string msg = null)
        {
            if(msg != null)
            {
                _("");
                if (msg != null) _(msg);
            }
            Console.Write(">> ");
            string line = Console.ReadLine();
            _("");
            if (line.Equals(Options.EXIT, StringComparison.CurrentCultureIgnoreCase))
                throw new OperationCanceledException();
            return line.Trim();
        }

        public static void WriteTitle()
        {
            _("********************************************");
            _("******** Customer Preference Center ********");
            _("********************************************");
            _("");
        }

        public static void ListCommands()
        {
            _($"{Options.ADD_NEW_CUSTOMER_PREFERENCE} - Add a new customer preference");
            _($"{Options.DELETE_CUSTOMER_PREFERENCE} - Delete a customer preference");
            _($"{Options.LIST_COSTOMER_PREFERENCES} - List all customer preferences");
            _($"{Options.REPORT_RECIPIENTS_FOR_DATE_RANGE} - Report of recipients on a date range");
            _($"{Options.LIST_OPTIONS} - Help, list out these apotions again");
            _($"{Options.EXIT} - End the application or Cancel an in progress operation");
        }

        public static void ListPreferenceOptions()
        {
            _("Enter one of the following preference options:");
            _($"{Options.EVERY_DAY_PREFERENCE} - Every day");
            _($"{Options.NEVER_PREFERENCE} - Never");
            _($"{Options.DAY_OF_MONTH_PREFERENCE} - Specific day of the month");
            _($"{Options.DAYS_OF_WEEK_PREFERENCE} - One or more days of the week");
        }
    }
}
