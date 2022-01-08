using PowerWaiters.Models;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class RestourantInfoService
    {
        public static RestourantInfo GetRestourantStats()
        {
            return new RestourantInfo
            {
                Name = "Italian Pizza",
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
        }
    }
}
