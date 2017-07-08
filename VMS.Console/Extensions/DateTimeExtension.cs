using System;

namespace VMS.Console.Extensions
{
    public static class DateTimeExtension
    {
        public static int ToUnixTime(this DateTime time)
        {
            int intResult = 0;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            intResult = Convert.ToInt32((time - startTime).TotalSeconds);
            return intResult;
        }
    }
}
