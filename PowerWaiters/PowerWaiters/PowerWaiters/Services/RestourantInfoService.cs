using PowerWaiters.Models;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class RestourantInfoService
    {
        public static RestourantInfo GetRestourantStats()
        {
            if (Client.TryGet(RequestUrl(), out RestaurantInfoDto restaurantInfoDto))
                return restaurantInfoDto.ConvertToRestaurantInfo();
            return new RestourantInfo
            {
                Name = "Ошибка",
                Statistics = new List<RestourantStatsModel>()
            };
        }

        private static string RequestUrl() => $"{Client.BaseServerAddress}/api/restaurant";
    }
}
