using System;
namespace CustomerPreferenceCenterLib.Preferences
{
    public class NeverPreference : IPreference
    {
        public bool SendOnDate(DateTime _) => false;

        public override string ToString() => "Never";
    }
}
