using System;
namespace CustomerPreferenceCenter.Lib.Preferences
{
    public class NeverPreference : IPreference
    {
        public bool SendOnDate(DateTime _) => false;

        public override string ToString() => "Never";
    }
}
