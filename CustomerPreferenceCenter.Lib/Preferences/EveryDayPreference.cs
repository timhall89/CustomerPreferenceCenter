using System;
namespace CustomerPreferenceCenter.Lib.Preferences
{
    public class EveryDayPreference : IPreference
    {
        public bool SendOnDate(DateTime _) => true;
    }
}
