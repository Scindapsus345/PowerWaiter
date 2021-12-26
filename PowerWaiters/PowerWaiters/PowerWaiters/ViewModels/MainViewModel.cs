using PowerWaiters.Models;
using PowerWaiters.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class MainViewModel : BindableObject
    {
        private RestourantStatsModel restourantStats;
        public RestourantStatsModel RestourantStats
        {
            get => restourantStats;
            set
            {
                if (value == restourantStats)
                    return;
                restourantStats = value;
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

        private int leaderboardItemHeight = 70;
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

        public MainViewModel()
        {
            LeaderboardItems = GetLeaderboardItems();
            RestourantStats = RestourantStatsService.GetRestourantStats();
        }

        private IEnumerable<LeaderboardItem> GetLeaderboardItems()
        {
            var waiters = WaiterInfoService.GetWaiters();
            return ConvertToLeaderboardItems(waiters);
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
                    Number = $"{i}.",
                    Scores = waiter.Scores,
                    BackgroundColor = waiter.IsCurrentUser ? "#F0FFF0" : "#D4D4D4",
                    BorderColor = GetColorByNumber(i)
                };
            }
        }

        private string GetColorByNumber(int number)
        {
            switch (number)
            {
                case 1:
                    return "#FFD700";
                case 2:
                    return "#C0C0C0";
                case 3:
                    return "#CD7F32";
                default:
                    return "#F1F1F1";
            }
        }
        private void UpdateLeaderboardHeight() => LeaderboardHeight = LeaderboardItems.Count() * LeaderboardItemHeight;
    }
}
