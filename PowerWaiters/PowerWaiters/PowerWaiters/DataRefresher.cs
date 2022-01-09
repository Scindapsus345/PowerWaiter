using PowerWaiters.Models;
using PowerWaiters.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PowerWaiters
{
    static class DataRefresher
    {
        public static IEnumerable<AchievementModel> AchievementModels { get; set; }
        public static UserInfo UserInfo { get; set; }
        public static Dictionary<StatisticsTimeSpan, StatisticsModel> StatisticsModelByFilter { get; set; }
        public static RestourantInfo RestourantInfo { get; set; }
        public static Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>> WaiterInfosByFilter { get; set; }
        public static IEnumerable<PurposeModel> PurposeModels { get; set; }
        private static LastUpdateDates lastUpdateDates { get; set; }

        public static async Task StartPolling()
        {
            while (true)
            {
                var refreshStatus = await RefreshService.GetRefreshStatus(lastUpdateDates);
                await TryRefreshData(refreshStatus);
                Thread.Sleep(20000);
            }
        }

        public static async Task InitialGetAllData()
        {
            await RefreshPersonalData();
            RestourantInfo = await RestourantInfoService.GetRestourantStats();
            WaiterInfosByFilter = await WaiterInfoService.GetWaiters();
            lastUpdateDates = new LastUpdateDates
            {
                Personal = DateTime.Now,
                Restourant = DateTime.Now,
                Leaderboard = DateTime.Now
            };
        }

        private static async Task TryRefreshData(RefreshStatus refreshStatus)
        {
            if (refreshStatus.Personal)
            {
                await RefreshPersonalData();
                lastUpdateDates.Personal = DateTime.Now;
            }
            if (refreshStatus.Restourant)
            {
                RestourantInfo = await RestourantInfoService.GetRestourantStats();
                lastUpdateDates.Restourant = DateTime.Now;
            }
            if (refreshStatus.Leaderboard)
            {
                WaiterInfosByFilter = await WaiterInfoService.GetWaiters();
                lastUpdateDates.Leaderboard = DateTime.Now;
            }
        }

        private static async Task RefreshPersonalData()
        {
            AchievementModels = await AchievementsService.GetAchievements().ConfigureAwait(false);
            UserInfo = await UserInfoService.GetUserInfo().ConfigureAwait(false);
            StatisticsModelByFilter = await StatisticsService.GetStatistics().ConfigureAwait(false);
            PurposeModels = await PurposesService.GetPurposes().ConfigureAwait(false);
        }
    }
}
