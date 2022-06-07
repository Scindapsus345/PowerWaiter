using PowerWaiters.Extensions;
using PowerWaiters.Models;
using PowerWaiters.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PowerWaiters.Views;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class MainViewModel : BindableObject
    {
        private RestourantInfo restourantInfo;
        public RestourantInfo RestourantInfo { 
            get => restourantInfo; 
            set
            {
                if (value == restourantInfo)
                    return;
                restourantInfo = value;
                RestourantStats = value.Statistics.Select(x => x.ConvertToDisplayModel());
                OnPropertyChanged();
            }
        }
        
        private IEnumerable<RestourantStatsDisplayModel> restourantStats;
        public IEnumerable<RestourantStatsDisplayModel> RestourantStats
        {
            get => restourantStats;
            set
            {
                if (value == restourantStats)
                    return;
                restourantStats = value;
                UpdateRestourantStatsHeight();
                OnPropertyChanged();
            }
        }

        private Dictionary<StatisticsType, IEnumerable<WaiterInfo>> waiterInfosByFilter;
        public Dictionary<StatisticsType, IEnumerable<WaiterInfo>> WaiterInfosByFilter
        {
            get => waiterInfosByFilter;
            set
            {
                if (value == waiterInfosByFilter)
                    return;
                waiterInfosByFilter = value;
                LeaderboardItems = ConvertToLeaderboardItems(value[currentType]);
                OnPropertyChanged();
            }
        }

        private IEnumerable<LeaderboardItem> leaderboardItems;
        public IEnumerable<LeaderboardItem> LeaderboardItems
        {
            get => leaderboardItems;
            set
            {
                if (value == leaderboardItems)
                    return;
                leaderboardItems = value;
                UpdateLeaderboardHeight();
                OnPropertyChanged();
            }
        }

        private int leaderboardHeight;
        public int LeaderboardHeight
        {
            get => leaderboardHeight;
            set
            {
                if (value == leaderboardHeight)
                    return;
                leaderboardHeight = value;
                OnPropertyChanged();
            }
        }

        private int leaderboardItemHeight = 60;
        public int LeaderboardItemHeight
        {
            get => leaderboardItemHeight;
            set
            {
                if (value == leaderboardItemHeight)
                    return;
                leaderboardItemHeight = value;
                OnPropertyChanged();
            }
        }

        private int restourantStatsHeight;
        public int RestourantStatsHeight
        {
            get => restourantStatsHeight;
            set
            {
                if (value == restourantStatsHeight)
                    return;
                restourantStatsHeight = value;
                OnPropertyChanged();
            }
        }

        private int restourantStatsBlockHeight = 150;
        public int RestourantStatsBlockHeight
        {
            get => restourantStatsBlockHeight;
            set
            {
                if (value == restourantStatsBlockHeight)
                    return;
                restourantStatsBlockHeight = value;
                OnPropertyChanged();
            }
        }
        public ICommand UpdateLeaderboard { get; }

        private StatisticsType currentType = StatisticsType.Xp;
        public string DayBtnColor => currentType == StatisticsType.Xp ? "#E7D8FF" : "Transparent";
        public string WeekBtnColor => currentType == StatisticsType.AverageCheque ? "#E7D8FF" : "Transparent";
        public string MonthBtnColor => currentType == StatisticsType.Golist ? "#E7D8FF" : "Transparent";

        public MainViewModel()
        {
            DataRefresher.LeaderboardDataChanged += OnLeaderboardDataChanged;
            DataRefresher.RestourantDataChanged += OnRestaurantDataChanged;
            UpdateLeaderboard = new Command<StatisticsType>(OnUpdateLeaderboard);
        }

        private void OnRestaurantDataChanged()
        {
            RestourantInfo = DataRefresher.RestourantInfo;
            OnPropertyChanged(nameof(RestourantInfo));
        }

        private void OnLeaderboardDataChanged()
        {
            WaiterInfosByFilter = DataRefresher.WaiterInfosByFilter;
            OnPropertyChanged(nameof(WaiterInfosByFilter));
        }

        private void OnUpdateLeaderboard(StatisticsType type)
        {
            currentType = type;
            LeaderboardItems = ConvertToLeaderboardItems(WaiterInfosByFilter[type]);
            OnPropertyChanged(nameof(DayBtnColor));
            OnPropertyChanged(nameof(WeekBtnColor));
            OnPropertyChanged(nameof(MonthBtnColor));
        }

        private IEnumerable<LeaderboardItem> ConvertToLeaderboardItems(IEnumerable<WaiterInfo> waiters)
        {
            var orderedWaiters = waiters.OrderByDescending(w => w.Scores).ToList();
            for (var i = 1; i <= orderedWaiters.Count; i++)
            {
                var waiter = orderedWaiters[i - 1];
                yield return new LeaderboardItem
                {
                    IsCurrentUser = waiter.CurrentUser,
                    Name = waiter.FullName,
                    Number = i.ToString(),
                    ScoresString = currentType == StatisticsType.Xp ? waiter.Scores.ToXPString()
                    : currentType == StatisticsType.AverageCheque ? waiter.Scores.ToCurrencyString():
                    waiter.Scores.ToFriendlyString(),
                    BackgroundColor = waiter.CurrentUser ? "#0C6000FF" : "Transparent",
                    CupName = GetCupNameNumber(i)
                };
            }
        }

        private string GetCupNameNumber(int i)
        {
            switch (i)
            {
                case 1:
                    return "gold_cup";
                case 2:
                    return "silver_cup";
                case 3:
                    return "bronze_cup";
                default:
                    return "";
            }

        }

        private void UpdateLeaderboardHeight() => LeaderboardHeight = LeaderboardItems.Count() * LeaderboardItemHeight;
        private void UpdateRestourantStatsHeight()
        {
            var count = RestourantStats.Count();
            RestourantStatsHeight = ((count / 2) + (count % 2)) * RestourantStatsBlockHeight;
        }
}
}
