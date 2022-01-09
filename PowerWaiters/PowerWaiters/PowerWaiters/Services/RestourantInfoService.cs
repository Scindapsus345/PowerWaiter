using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PowerWaiters.Services
{
    static class RestourantInfoService
    {
        private static RestourantInfo formatErrorData = new RestourantInfo
        {
            Name = "ОШИБКА ФОРМАТА",
            RestourantStatsModels = new List<RestourantStatsModel>
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

        public static async Task<RestourantInfo> GetRestourantStats()
        {
            HttpResponseMessage response;
            using (var client = Client.HttpClient)
            {
                try
                {
                    response = await client.GetAsync(RequestUrl(2));
                }
                catch
                {
                    return null;
                }
            }
            return await JsonDeserializeHelper.TryDeserialise(response, formatErrorData);
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/restourant";
    }
}
