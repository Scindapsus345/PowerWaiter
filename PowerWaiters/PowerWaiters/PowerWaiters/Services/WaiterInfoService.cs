using PowerWaiters.Models;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class WaiterInfoService
    {
        public static IEnumerable<WaiterInfo> GetWaiters(StatisticsTimeSpan timeSpan)
        {
            return new List<WaiterInfo>
            {
                new WaiterInfo
                {
                    FirstName = "Игорь",
                    LastName = "Замощанский",
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
