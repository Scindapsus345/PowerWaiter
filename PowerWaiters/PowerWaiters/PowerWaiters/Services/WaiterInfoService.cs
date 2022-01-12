using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class WaiterInfoService
    {
        public static Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>> GetWaiters()
        {
            var waiterInfoByFilter = new Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>>();
            waiterInfoByFilter[StatisticsTimeSpan.Day] = GetWaiters(StatisticsTimeSpan.Day);
            waiterInfoByFilter[StatisticsTimeSpan.Week] = GetWaiters(StatisticsTimeSpan.Week);
            waiterInfoByFilter[StatisticsTimeSpan.Month] = GetWaiters(StatisticsTimeSpan.Month);
            return waiterInfoByFilter;
        }

        private static IEnumerable<WaiterInfo> GetWaiters(StatisticsTimeSpan timeSpan)
        {
            var response = Client.HttpClient.GetAsync(RequestUrl(timeSpan, Client.UserId)).Result;
                if (!response.IsSuccessStatusCode)
                    return new List<WaiterInfo>();
            
            return JsonDeserializeHelper.TryDeserialise(response, FormatErrorData(timeSpan)).Result;
        }

        private static string RequestUrl(StatisticsTimeSpan timeSpan, int userId) =>
            $"{Client.BaseServerAddress}/waiters/{userId}/filter?{TimeSpanToFilterConverter.Convert(timeSpan)}";

        private static WaiterInfo[] FormatErrorData(StatisticsTimeSpan timeSpan)
        {
            return new []
            {
                new WaiterInfo
                {
                    FirstName = "ОШИБКА",
                    LastName = "ФОРМАТА",
                    CurrentUser = false,
                    Scores = 112 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Арслан",
                    LastName = "Байкенов",
                    CurrentUser = false,
                    Scores = 8 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Александр",
                    LastName = "Рыбалко",
                    CurrentUser = false,
                    Scores = 619 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Елена",
                    LastName = "Лобашева",
                    CurrentUser = false,
                    Scores =1544 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Константин",
                    LastName = "Ефимов",
                    CurrentUser = false,
                    Scores = 2480 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Евгений",
                    LastName = "Ботов",
                    CurrentUser = false,
                    Scores = 1256 + ((int)timeSpan)
                },
                new WaiterInfo
                {
                    FirstName = "Игорь",
                    LastName = "Голдберг",
                    CurrentUser = true,
                    Scores = 3672 + ((int)timeSpan)
                },
            };
        }
    }
}
