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

        private IEnumerable<AchievementDisplayModel> achievementDisplayModels;
        public IEnumerable<AchievementDisplayModel> AchievementDisplayModels
        {
            get => achievementDisplayModels;
            set
            {
                if (value == achievementDisplayModels)
                    return;
                achievementDisplayModels = value;
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

        private int statsBlockHeight = 120;
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

        private int achievementBlockHeight = 210;
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
        public string DayBtnColor => currentTimeSpan == StatisticsTimeSpan.Day ? "#E7D8FF" : "Transparent";
        public string WeekBtnColor => currentTimeSpan == StatisticsTimeSpan.Week ? "#E7D8FF" : "Transparent";
        public string MonthBtnColor => currentTimeSpan == StatisticsTimeSpan.Month ? "#E7D8FF" : "Transparent";

        public ProfileViewModel()
        {
            StatisticsDisplayModels = StatisticsService.GetStatistics(StatisticsTimeSpan.Day).ConvertToStatisticsDisplayModels();
            AchievementDisplayModels = AchievementsService.GetAchievements().Select(am => am.ConvertToDisplayModel());
            User = UserInfoService.GetUserInfo();
            UpdateStatistics = new Command<StatisticsTimeSpan>(OnUpdateStatistics);
        }

        private void OnUpdateStatistics(StatisticsTimeSpan timeSpan)
        {
            StatisticsDisplayModels = StatisticsService.GetStatistics(timeSpan).ConvertToStatisticsDisplayModels();
            currentTimeSpan = timeSpan;
            OnPropertyChanged(nameof(DayBtnColor));
            OnPropertyChanged(nameof(WeekBtnColor));
            OnPropertyChanged(nameof(MonthBtnColor));
        }

        private void UpdateStatisticsHeight()
        {
            var count = StatisticsDisplayModels.Count();
            StatisticsHeight = ((count / 2) + (count % 2)) * StatsBlockHeight;
        }

        private void UpdateAchievementsHeight() => AchievementsHeight = AchievementDisplayModels.Count() * AchievementBlockHeight;
    }
}
