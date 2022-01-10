using PowerWaiters.Models;
using PowerWaiters.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PowerWaiters
{
    static class DataRefresher
    {
        public static IEnumerable<AchievementModel> AchievementModels { get; private set; }
        public static UserInfo UserInfo { get; private set; }
        public static Dictionary<StatisticsTimeSpan, StatisticsModel> StatisticsModelByFilter { get; private set; }
        public static RestourantInfo RestourantInfo { get; private set; }
        public static Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>> WaiterInfosByFilter { get; private set; }
        public static IEnumerable<PurposeModel> PurposeModels { get; private set; }
        private static LastUpdateDates LastUpdateDates { get; set; }

        public static event Action PersonalDataChanged;
        public static event Action RestourantDataChanged;
        public static event Action LeaderboardDataChanged;

        public static async Task StartPolling()
        {
            while (true)
            {
                Thread.Sleep(5000);
                var refreshStatus = await RefreshService.GetRefreshStatus(LastUpdateDates);
                await TryRefreshData(refreshStatus);
            }
        }

        public static async Task InitialGetAllData()
        {
            LastUpdateDates = new LastUpdateDates();
            await RefreshPersonalData();
            await RefreshRestaurantData();
            await RefreshLeaderboardData();
        }

        private static async Task TryRefreshData(RefreshStatus refreshStatus)
        {
            if (refreshStatus.Personal)
                await RefreshPersonalData();
            if (refreshStatus.Restourant)
                await RefreshRestaurantData();
            if (refreshStatus.Leaderboard)
                await RefreshLeaderboardData();
        }

        private static async Task RefreshPersonalData()
        {
            AchievementModels = await AchievementsService.GetAchievements().ConfigureAwait(false);
            UserInfo = await UserInfoService.GetUserInfo().ConfigureAwait(false);
            StatisticsModelByFilter = await StatisticsService.GetStatistics().ConfigureAwait(false);
            PurposeModels = await PurposesService.GetPurposes().ConfigureAwait(false);
            LastUpdateDates.Personal = DateTime.Now;
            PersonalDataChanged.Invoke();
        }

        private static async Task RefreshRestaurantData()
        {
            RestourantInfo = await RestourantInfoService.GetRestourantStats();
            LastUpdateDates.Restourant = DateTime.Now;
            RestourantDataChanged.Invoke();
        }

        private static async Task RefreshLeaderboardData()
        {
            WaiterInfosByFilter = await WaiterInfoService.GetWaiters();
            LastUpdateDates.Leaderboard = DateTime.Now;
            LeaderboardDataChanged.Invoke();
        }
    }
}
