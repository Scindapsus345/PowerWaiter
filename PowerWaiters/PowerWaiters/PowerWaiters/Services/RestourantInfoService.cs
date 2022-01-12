using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class RestourantInfoService
    {
        private static RestourantInfo formatErrorData = new RestourantInfo
        {
            Name = "ОШИБКА ФОРМАТА",
            Statistics = new List<RestourantStatsModel>
                {
                    new RestourantStatsModel
                    {
                        Name = "Выручка",
                        Progress = 891563,
                        Purpose = 1000000,
                        Deadline = "27.02.2023"
                    },
                    new RestourantStatsModel
                    {
                        Name = "Обслуженные гости",
                        Progress = 2699,
                        Purpose = 2000,
                        Deadline = "12.05.2023"
                    },
                    new RestourantStatsModel
                    {
                        Name = "Go-лист",
                        Progress = 12,
                        Purpose = 300,
                        Deadline = "12.05.2023"
                    }
                }
        };

        public static RestourantInfo GetRestourantStats()
        {
            var response = Client.HttpClient.GetAsync(RequestUrl()).Result;
            if (!response.IsSuccessStatusCode)
                return null;
            return JsonDeserializeHelper.TryDeserialise(response, formatErrorData).Result;
        }

        private static string RequestUrl() => $"{Client.BaseServerAddress}/mission/all";
    }
}
