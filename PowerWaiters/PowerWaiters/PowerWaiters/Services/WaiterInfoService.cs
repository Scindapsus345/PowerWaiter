using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class WaiterInfoService
    {
        public static Dictionary<StatisticsType, IEnumerable<WaiterInfo>> GetWaiters()
        {
            var waiterInfoByFilter = new Dictionary<StatisticsType, IEnumerable<WaiterInfo>>();
            waiterInfoByFilter[StatisticsType.Xp] = GetWaiters(StatisticsType.Xp);
            waiterInfoByFilter[StatisticsType.AverageCheque] = GetWaiters(StatisticsType.AverageCheque);
            waiterInfoByFilter[StatisticsType.Golist] = GetWaiters(StatisticsType.Golist);
            return waiterInfoByFilter;
        }

        private static IEnumerable<WaiterInfo> GetWaiters(StatisticsType type)
        {
            if (Client.TryGet(RequestUrl(type, Client.UserId), out WaiterInfo[] waiterInfos))
                return waiterInfos;
            return new List<WaiterInfo>();
        }

        private static string RequestUrl(StatisticsType type, int userId) =>
            $"{Client.BaseServerAddress}/waiters/{userId}/type?{StatisticsTypeToQueryConverter.Convert(type)}";
    }
}
