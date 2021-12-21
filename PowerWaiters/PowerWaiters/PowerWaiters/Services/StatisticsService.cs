using PowerWaiters.Models;

namespace PowerWaiters.Services
{
    static class StatisticsService
    {
        static public StatisticsModel GetStatistics(StatisticsTimeSpan timeSpan)
        {
            return new StatisticsModel
            {
                ServedGuests = 200,
                DailyRevenue = 100,
                DishesByGoList = 50,
                OrdersClosed = 20,
                DigitizedGuests = 10
            };
        }
    }
}
