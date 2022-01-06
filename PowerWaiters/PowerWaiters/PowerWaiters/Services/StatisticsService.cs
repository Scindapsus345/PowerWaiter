using PowerWaiters.Models;

namespace PowerWaiters.Services
{
    static class StatisticsService
    {
        static public StatisticsModel GetStatistics(StatisticsTimeSpan timeSpan)
        {
            switch (timeSpan)
            {
                case StatisticsTimeSpan.Day:
                    return new StatisticsModel
                    {
                        Rating = 200,
                        DailyRevenue = 100,
                        DishesByGoList = 50,
                        OrdersClosed = 20,
                        DigitizedGuests = 10
                    };
                case StatisticsTimeSpan.Week:
                    return new StatisticsModel
                    {
                        Rating = 500,
                        DailyRevenue = 200,
                        DishesByGoList = 150,
                        OrdersClosed = 50,
                        DigitizedGuests = 12
                    };
                case StatisticsTimeSpan.Month:
                    return new StatisticsModel
                    {
                        Rating = 1800,
                        DailyRevenue = 920,
                        DishesByGoList = 340,
                        OrdersClosed = 102,
                        DigitizedGuests = 36
                    };
                default:
                    return new StatisticsModel();
            }
        }
    }
}
