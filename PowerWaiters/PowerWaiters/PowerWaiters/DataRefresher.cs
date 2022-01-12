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

        public static Task StartPolling()
        {
            while (true)
            {
                Thread.Sleep(5000);
                var refreshStatus = RefreshService.GetRefreshStatus(LastUpdateDates);
                TryRefreshData(refreshStatus);
            }
        }

        public static void InitialGetAllData()
        {
            LastUpdateDates = new LastUpdateDates()
            {
                Personal = DateTime.Now,
                Leaderboard = DateTime.Now,
                Restaurant = DateTime.Now
            };
            RefreshPersonalData();
            RefreshRestaurantData();
            RefreshLeaderboardData();
        }

        private static void TryRefreshData(RefreshStatus refreshStatus)
        {
            if (refreshStatus.Personal)
                RefreshPersonalData();
            if (refreshStatus.Restourant)
                RefreshRestaurantData();
            if (refreshStatus.Leaderboard)
                RefreshLeaderboardData();
        }

        private static void RefreshPersonalData()
        {
            AchievementModels = AchievementsService.GetAchievements();
            UserInfo = UserInfoService.GetUserInfo();
            StatisticsModelByFilter = StatisticsService.GetStatistics();
            PurposeModels = PurposesService.GetPurposes();
            LastUpdateDates.Personal = DateTime.Now;
            PersonalDataChanged.Invoke();
        }

        private static void RefreshRestaurantData()
        {
            RestourantInfo = RestourantInfoService.GetRestourantStats();
            LastUpdateDates.Restaurant = DateTime.Now;
            RestourantDataChanged.Invoke();
        }

        private static void RefreshLeaderboardData()
        {
            WaiterInfosByFilter = WaiterInfoService.GetWaiters();
            LastUpdateDates.Leaderboard = DateTime.Now;
            LeaderboardDataChanged.Invoke();
        }
    }
}
