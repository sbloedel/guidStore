using System;

namespace guidStore.Utils 
{
    public class DateTimeUtils {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static int DateTimeToEpoch(DateTime dateTime)
        {
            TimeSpan span = dateTime - epoch;
            return (int)span.TotalSeconds;
        }

        public static DateTime EpochToDateTime(int unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }
    }
}