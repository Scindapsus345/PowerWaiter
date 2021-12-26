using PowerWaiters.Models;
using PowerWaiters.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class ProfileViewModel : BindableObject
    {
        private IEnumerable<StatisticsDisplayModel> statisticsDisplayModels;
        public IEnumerable<StatisticsDisplayModel> StatisticsDisplayModels
        {
            get => statisticsDisplayModels;
            set
            {
                if (value == statisticsDisplayModels)
                    return;
                statisticsDisplayModels = value;
                UpdateStatisticsHeight();
                OnPropertyChanged();
            }
        }

        private IEnumerable<AchievementModel> achievementModels;
        public IEnumerable<AchievementModel> AchievementModels
        {
            get => achievementModels;
            set
            {
                if (value == achievementModels)
                    return;
                achievementModels = value;
                UpdateAchievementsHeight();
                OnPropertyChanged();
            }
        }

        public ICommand UpdateStatistics { get; }

        private UserInfo user;
        public UserInfo User
        {
            get => user;
            set
            {
                if (value == user)
                    return;
                user = value;
                OnPropertyChanged();
            }
        }

        private int statisticsHeight;
        public int StatisticsHeight
        {
            get => statisticsHeight;
            set
            {
                if (value == statisticsHeight)
                    return;
                statisticsHeight = value;
                OnPropertyChanged();
            }
        }

        private int statsBlockHeight = 100;
        public int StatsBlockHeight
        {
            get => statsBlockHeight;
            set
            {
                if (value == statsBlockHeight)
                    return;
                statsBlockHeight = value;
                OnPropertyChanged();
            }
        }

        private int achievementsHeight;
        public int AchievementsHeight
        {
            get => achievementsHeight;
            set
            {
                if (value == achievementsHeight)
                    return;
                achievementsHeight = value;
                OnPropertyChanged();
            }
        }

        private int achievementBlockHeight = 150;
        public int AchievementBlockHeight
        {
            get => achievementBlockHeight;
            set
            {
                if (value == achievementBlockHeight)
                    return;
                achievementBlockHeight = value;
                OnPropertyChanged();
            }
        }

        private StatisticsTimeSpan currentTimeSpan;
        public int DayBtnBorderSize => currentTimeSpan == StatisticsTimeSpan.Day ? 2 : 0;
        public int WeekBtnBorderSize => currentTimeSpan == StatisticsTimeSpan.Week ? 2 : 0;
        public int MonthBtnBorderSize => currentTimeSpan == StatisticsTimeSpan.Month ? 2 : 0;

        public ProfileViewModel()
        {
            StatisticsDisplayModels = GetStatisticDisplayModels(StatisticsService.GetStatistics(StatisticsTimeSpan.Day));
            AchievementModels = AchievementsService.GetAchievements();
            User = UserInfoService.GetUserInfo();
            UpdateStatistics = new Command<StatisticsTimeSpan>(OnUpdateStatistics);
        }

        private void OnUpdateStatistics(StatisticsTimeSpan timeSpan)
        {
            StatisticsDisplayModels = GetStatisticDisplayModels(StatisticsService.GetStatistics(timeSpan));
            currentTimeSpan = timeSpan;
            OnPropertyChanged(nameof(DayBtnBorderSize));
            OnPropertyChanged(nameof(WeekBtnBorderSize));
            OnPropertyChanged(nameof(MonthBtnBorderSize));
        }

        private static List<StatisticsDisplayModel> GetStatisticDisplayModels(StatisticsModel statisticsModel)
        {
            var statisticsDisplayModels = new List<StatisticsDisplayModel>();
            if (statisticsModel.ServedGuests != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Обслуженные гости", statisticsModel.ServedGuests.Value.ToString()));
            if (statisticsModel.DailyRevenue != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Дневная выручка", statisticsModel.DailyRevenue.Value.ToString()));
            if (statisticsModel.DishesByGoList != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Блюд по Go листу", statisticsModel.DishesByGoList.Value.ToString()));
            if (statisticsModel.OrdersClosed != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Заказов закрыто", statisticsModel.OrdersClosed.Value.ToString()));
            if (statisticsModel.DigitizedGuests != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Оцифрованные гости", statisticsModel.DigitizedGuests.Value.ToString()));
            return statisticsDisplayModels;
        }

        private void UpdateStatisticsHeight()
        {
            var count = StatisticsDisplayModels.Count();
            StatisticsHeight = ((count / 2) + (count % 2)) * StatsBlockHeight;
        }

        private void UpdateAchievementsHeight() => AchievementsHeight = AchievementModels.Count() * AchievementBlockHeight;
    }
}
