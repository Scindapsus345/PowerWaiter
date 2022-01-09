using PowerWaiters.Extensions;
using PowerWaiters.Models;
using PowerWaiters.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
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
                RestourantStats = value.RestourantStatsModels.Select(x => x.ConvertToDisplayModel());
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

        private Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>> waiterInfosByFilter;
        public Dictionary<StatisticsTimeSpan, IEnumerable<WaiterInfo>> WaiterInfosByFilter
        {
            get => waiterInfosByFilter;
            set
            {
                if (value == waiterInfosByFilter)
                    return;
                waiterInfosByFilter = value;
                LeaderboardItems = ConvertToLeaderboardItems(value[currentTimeSpan]);
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

        private StatisticsTimeSpan currentTimeSpan = StatisticsTimeSpan.Day;
        public string DayBtnColor => currentTimeSpan == StatisticsTimeSpan.Day ? "#E7D8FF" : "Transparent";
        public string WeekBtnColor => currentTimeSpan == StatisticsTimeSpan.Week ? "#E7D8FF" : "Transparent";
        public string MonthBtnColor => currentTimeSpan == StatisticsTimeSpan.Month ? "#E7D8FF" : "Transparent";

        public MainViewModel()
        {
            WaiterInfosByFilter = DataRefresher.WaiterInfosByFilter;
            RestourantInfo = DataRefresher.RestourantInfo;
            UpdateLeaderboard = new Command<StatisticsTimeSpan>(OnUpdateLeaderboard);
        }

        private void OnUpdateLeaderboard(StatisticsTimeSpan timeSpan)
        {
            LeaderboardItems = ConvertToLeaderboardItems(WaiterInfosByFilter[timeSpan]);
            currentTimeSpan = timeSpan;
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
                    IsCurrentUser = waiter.IsCurrentUser,
                    Name = waiter.FullName,
                    Number = i.ToString(),
                    ScoresString = waiter.Scores.ToXPString(),
                    BackgroundColor = waiter.IsCurrentUser ? "#0C6000FF" : "Transparent",
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
        private void UpdateRestourantStatsHeight() => RestourantStatsHeight = RestourantStats.Count() * restourantStatsBlockHeight;
    }
}
