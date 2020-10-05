using System;
namespace CustomerPreferenceCenter.Lib
{
    public class EveryDayPreference : IPreference
    {
        public bool SendOnDate(DateTime _) => true;
    }
}
