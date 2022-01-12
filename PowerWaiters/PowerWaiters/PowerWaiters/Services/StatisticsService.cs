using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class StatisticsService
    {
        static public Dictionary<StatisticsTimeSpan, StatisticsModel> GetStatistics()
        {
            var statisticsModelsByFilter = new Dictionary<StatisticsTimeSpan, StatisticsModel>();
            statisticsModelsByFilter[StatisticsTimeSpan.Day] = GetStatistics(StatisticsTimeSpan.Day);
            statisticsModelsByFilter[StatisticsTimeSpan.Week] = GetStatistics(StatisticsTimeSpan.Week);
            statisticsModelsByFilter[StatisticsTimeSpan.Month] = GetStatistics(StatisticsTimeSpan.Month);
            return statisticsModelsByFilter;
        }

        private static StatisticsModel GetStatistics(StatisticsTimeSpan timeSpan)
        {

            var response = Client.HttpClient.GetAsync(RequestUrl(Client.UserId, timeSpan)).Result;
            if (!response.IsSuccessStatusCode)
                return null;
            return JsonDeserializeHelper.TryDeserialise(response, FormatErrorData(timeSpan)).Result;
        }

        private static string RequestUrl(int userId, StatisticsTimeSpan timeSpan) => 
            $"{Client.BaseServerAddress}/waiters/{userId}/statistics?{TimeSpanToFilterConverter.Convert(timeSpan)}";

        private static StatisticsModel FormatErrorData(StatisticsTimeSpan timeSpan)
        {
            switch (timeSpan)
            {
                case StatisticsTimeSpan.Day:
                    return new StatisticsModel
                    {
                        Rating = 200,
                        Revenue = 100,
                        GoList = 50,
                        Orders = 20,
                        Checkins = 10
                    };
                case StatisticsTimeSpan.Week:
                    return new StatisticsModel
                    {
                        Rating = 500,
                        Revenue = 200,
                        GoList = 150,
                        Orders = 50,
                        Checkins = 12
                    };
                case StatisticsTimeSpan.Month:
                    return new StatisticsModel
                    {
                        Rating = 1800,
                        Revenue = 920,
                        GoList = 340,
                        Orders = 102,
                        Checkins = 36
                    };
                default:
                    return new StatisticsModel();
            }
        }
    }
}
