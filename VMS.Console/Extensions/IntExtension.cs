using System;

namespace VMS.Console.Extensions
{
    public static class IntExtension
    {
        public static DateTime ToDateTimeFromUnixTime(this int unixTimestamp)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var time = startTime.AddSeconds(unixTimestamp);
            return time;
        }
    }
}
