using PowerWaiters.Models;
using System;

namespace PowerWaiters.Helpers
{
    public static class TimeSpanToFilterConverter
    {
        public static string Convert(StatisticsTimeSpan timeSpan)
        {
            switch (timeSpan)
            {
                case StatisticsTimeSpan.Day:
                    return "filter=day";
                case StatisticsTimeSpan.Week:
                    return "filter=week";
                case StatisticsTimeSpan.Month:
                    return "filter=month";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
