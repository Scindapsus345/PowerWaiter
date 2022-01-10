using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PowerWaiters.Services
{
    static class WaiterInfoService
    {
        public static async Task<Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>>> GetWaiters()
        {
            var waiterInfoByFilter = new Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>>();
            waiterInfoByFilter[StatisticsTimeSpan.Day] = await GetWaiters(StatisticsTimeSpan.Day);
            waiterInfoByFilter[StatisticsTimeSpan.Week] = await GetWaiters(StatisticsTimeSpan.Week);
            waiterInfoByFilter[StatisticsTimeSpan.Month] = await GetWaiters(StatisticsTimeSpan.Month);
            return waiterInfoByFilter;
        }

        private static async Task<IEnumerable<WaiterInfo>> GetWaiters(StatisticsTimeSpan timeSpan)
        {
            return FormatErrorData(timeSpan);
            HttpResponseMessage response;
            using (var client = Client.HttpClient)
            {
                try
                {
                    response = await client.GetAsync(RequestUrl(timeSpan));
                }
                catch
                {
                    return null;
                }
            }
            return await JsonDeserializeHelper.TryDeserialise(response, FormatErrorData(timeSpan));
        }

        private static string RequestUrl(StatisticsTimeSpan timeSpan) =>
            $"{Client.BaseServerAddress}/waiters/filter?{TimeSpanToFilterConverter.Convert(timeSpan)}";

        private static List<WaiterInfo> FormatErrorData(StatisticsTimeSpan timeSpan)
        {
            return new List<WaiterInfo>
            {
                new WaiterInfo
                {
                    FirstName = "ОШИБКА",
                    LastName = "ФОРМАТА",
                    IsCurrentUser = false,
                    Scores = 112 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Арслан",
                    LastName = "Байкенов",
                    IsCurrentUser = false,
                    Scores = 8 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Александр",
                    LastName = "Рыбалко",
                    IsCurrentUser = false,
                    Scores = 619 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Елена",
                    LastName = "Лобашева",
                    IsCurrentUser = false,
                    Scores =1544 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Константин",
                    LastName = "Ефимов",
                    IsCurrentUser = false,
                    Scores = 2480 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Евгений",
                    LastName = "Ботов",
                    IsCurrentUser = false,
                    Scores = 1256 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Игорь",
                    LastName = "Голдберг",
                    IsCurrentUser = true,
                    Scores = 3672 + ((int)timeSpan)
                },
            };
        }
    }
}
