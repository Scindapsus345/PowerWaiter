using PowerWaiters.Models;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class WaiterInfoService
    {
        public static IEnumerable<WaiterInfo> GetWaiters()
        {
            return new List<WaiterInfo>
            {
                new WaiterInfo
                {
                    FirstName = "Игорь",
                    LastName = "Замощанский",
                    IsCurrentUser = false,
                    Scores = 112
                },
                new WaiterInfo
                {
                    FirstName = "Арслан",
                    LastName = "Байкенов",
                    IsCurrentUser = false,
                    Scores = 8
                },
                new WaiterInfo
                {
                    FirstName = "Александр",
                    LastName = "Рыбалко",
                    IsCurrentUser = false,
                    Scores = 619
                },
                new WaiterInfo
                {
                    FirstName = "Елена",
                    LastName = "Лобашева",
                    IsCurrentUser = false,
                    Scores =1544
                },
                new WaiterInfo
                {
                    FirstName = "Константин",
                    LastName = "Ефимов",
                    IsCurrentUser = false,
                    Scores = 2480
                },
                new WaiterInfo
                {
                    FirstName = "Евгений",
                    LastName = "Ботов",
                    IsCurrentUser = false,
                    Scores = 1256
                },
                new WaiterInfo
                {
                    FirstName = "Игорь",
                    LastName = "Голдберг",
                    IsCurrentUser = true,
                    Scores = 3672
                },
            };
        }
    }
}
