using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class StatisticsService
    {
        static public async Task<Dictionary<StatisticsTimeSpan, StatisticsModel>> GetStatistics()
        {
            var statisticsModelsByFilter = new Dictionary<StatisticsTimeSpan, StatisticsModel>();
            statisticsModelsByFilter[StatisticsTimeSpan.Day] = await GetStatistics(StatisticsTimeSpan.Day);
            statisticsModelsByFilter[StatisticsTimeSpan.Week] = await GetStatistics(StatisticsTimeSpan.Week);
            statisticsModelsByFilter[StatisticsTimeSpan.Month] = await GetStatistics(StatisticsTimeSpan.Month);
            return statisticsModelsByFilter;
        }

        private static async Task<StatisticsModel> GetStatistics(StatisticsTimeSpan timeSpan)
        {
            return FormatErrorData(timeSpan);
            HttpResponseMessage response;
            using (var client = Client.HttpClient)
            {
                try
                {
                    response = await client.GetAsync(RequestUrl(2, timeSpan));
                }
                catch
                {
                    return null;
                }
            }
            return await JsonDeserializeHelper.TryDeserialise(response, FormatErrorData(timeSpan));
        }

        private static string RequestUrl(int userId, StatisticsTimeSpan timeSpan) => 
            $"{Client.BaseServerAddress}/waiters/{userId}/statistics{TimeSpanToFilterConverter.Convert(timeSpan)}";

        private static StatisticsModel FormatErrorData(StatisticsTimeSpan timeSpan)
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
