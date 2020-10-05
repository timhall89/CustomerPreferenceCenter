using System;
namespace CustomerPreferenceCenter.Lib.Preferences
{
    public interface IPreference
    {
        bool SendOnDate(DateTime date);
    }
}
