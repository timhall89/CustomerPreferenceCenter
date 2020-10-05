using System;
namespace CustomerPreferenceCenter.Lib
{
    public class NeverPreference : IPreference
    {
        public bool SendOnDate(DateTime _) => false;
    }
}
