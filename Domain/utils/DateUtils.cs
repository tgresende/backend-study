using System;
namespace Domain.utils
{
    public static class DateUtils
    {
        private const int secondsPerMinute = 60;
        private const int minutesPerHour = 60;
        private const int HoursPerDay = 24;

        public static long GetDayBeforeNowTimestamp(int days) => 
            GetNowTimestamp() - ConvertDaysToTimestamp(days);

        public static int ConvertDaysToTimestamp(int days) => 
            secondsPerMinute * minutesPerHour * HoursPerDay * days;

        public static long GetNowTimestamp() => 
            new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        
    }
}