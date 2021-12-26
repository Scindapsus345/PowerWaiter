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
                    FirstName = "Ivan",
                    LastName = "Petrov",
                    IsCurrentUser = false,
                    Scores = 100
                },
                new WaiterInfo
                {
                    FirstName = "Tut",
                    LastName = "Tam",
                    IsCurrentUser = false,
                    Scores = 80
                },
                new WaiterInfo
                {
                    FirstName = "Lox",
                    LastName = "Nelox",
                    IsCurrentUser = false,
                    Scores = 60
                },
                new WaiterInfo
                {
                    FirstName = "Evgeniy",
                    LastName = "Pots",
                    IsCurrentUser = false,
                    Scores = 120
                },
                new WaiterInfo
                {
                    FirstName = "Petr",
                    LastName = "Ivanov",
                    IsCurrentUser = true,
                    Scores = 160
                },
            };
        }
    }
}
