using System;
namespace CustomerPreferenceCenterLib.Preferences
{
    public class EveryDayPreference : IPreference
    {
        public bool SendOnDate(DateTime _) => true;

        public override string ToString() => "Every Day";
    }
}
