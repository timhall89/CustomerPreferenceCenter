using System;
namespace CustomerPreferenceCenterConsole
{
    public static class ConsoleReaderAndWriter
    {
        private const string EXIT_COMMAND = "EXIT";

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
            _("");
            Console.Write(">> ");
            string line = Console.ReadLine();
            _("");
            if (line.ToUpper().Equals(EXIT_COMMAND.ToUpper())) throw new OperationCanceledException();
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
            _("A - Add a new customer preference");
            _("D - Delete a customer preference");
            _("L - List all customer preferences");
            _("R - Report of recipients on a date range");
            _("H - Help, list out these apotions again");
            _("EXIT - End the application");
        }

        public static void ListPreferenceOptions()
        {
            _("Enter one of the following preference options:");
            _("E - Every day");
            _("N - Never");
            _("M - Specific day of the month");
            _("W - One or more days of the week");
        }
    }
}
