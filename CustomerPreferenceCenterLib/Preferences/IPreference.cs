using System;
namespace CustomerPreferenceCenterLib.Preferences
{
    public interface IPreference
    {
        bool SendOnDate(DateTime date);
    }
}
