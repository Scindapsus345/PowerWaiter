using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class StatisticsService
    {
        static public Dictionary<StatisticsType, StatisticsModel> GetStatistics()
        {
            var statisticsModelsByFilter = new Dictionary<StatisticsType, StatisticsModel>();
            statisticsModelsByFilter[StatisticsType.Xp] = GetStatistics(StatisticsType.Xp);
            statisticsModelsByFilter[StatisticsType.AverageCheque] = GetStatistics(StatisticsType.AverageCheque);
            statisticsModelsByFilter[StatisticsType.Golist] = GetStatistics(StatisticsType.Golist);
            return statisticsModelsByFilter;
        }

        private static StatisticsModel GetStatistics(StatisticsType type)
        {
            if (Client.TryGet(RequestUrl(Client.UserId, type), out StatisticsModel statisticsModel))
                return statisticsModel;
            return new StatisticsModel();
        }

        private static string RequestUrl(int userId, StatisticsType type) => 
            $"{Client.BaseServerAddress}/waiters/{userId}/statistics";
    }
}
