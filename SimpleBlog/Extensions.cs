using System;
using System.Configuration;

namespace SimpleBlog
{
    public static class Extensions
    {
        public static string ToConfigLocalTime(this DateTime utcDateTime)
        {
            var currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["Timezone"]);
            return $"{TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, currentTimeZone).ToShortDateString()} ({ConfigurationManager.AppSettings["TimezoneAbbr"]})";
        }
    }
}