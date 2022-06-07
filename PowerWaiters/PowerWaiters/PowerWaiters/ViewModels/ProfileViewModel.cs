using PowerWaiters.Models;
using PowerWaiters.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PowerWaiters.Views;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class ProfileViewModel : BindableObject
    {
        private Dictionary<StatisticsType, StatisticsModel> statisticsModelByFilter;
        public Dictionary<StatisticsType, StatisticsModel> StatisticsModelByFilter
        {
            get => statisticsModelByFilter;
            set
            {
                if (value == statisticsModelByFilter)
                    return;
                statisticsModelByFilter = value;
                StatisticsDisplayModels = value[currentType].ConvertToStatisticsDisplayModels();
                OnPropertyChanged();
            }
        }

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
                AchievementDisplayModels = value.Select(am => am.ConvertToDisplayModel());
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

        private UserInfo userInfo;
        public UserInfo UserInfo
        {
            get => userInfo;
            set
            {
                if (value == userInfo)
                    return;
                userInfo = value;
                UserDisplayModel = value.ConvertToDisplayModel();
                OnPropertyChanged();
            }
        }

        private UserDisplayModel userDisplayModel;
        public UserDisplayModel UserDisplayModel
        {
            get => userDisplayModel;
            set
            {
                if (value == userDisplayModel)
                    return;
                userDisplayModel = value;
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

        private int achievementBlockHeight = 145;
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

        public ICommand UpdateStatistics { get; }
        public ICommand OpenAchievements { get; }

        public string DayBtnColor => currentType == StatisticsType.Xp ? "#E7D8FF" : "Transparent";
        public string WeekBtnColor => currentType == StatisticsType.AverageCheque ? "#E7D8FF" : "Transparent";
        public string MonthBtnColor => currentType == StatisticsType.Golist ? "#E7D8FF" : "Transparent";
        private StatisticsType currentType;

        public ProfileViewModel()
        {
            DataRefresher.PersonalDataChanged += OnPersonalDataChanged;
            UpdateStatistics = new Command<StatisticsType>(OnUpdateStatistics);
            OpenAchievements = new Command(() => App.Current.MainPage.Navigation.PushAsync(new AchievementsPage()));
        }

        private void OnUpdateStatistics(StatisticsType type)
        {
            currentType = type;
            StatisticsDisplayModels = StatisticsModelByFilter[type].ConvertToStatisticsDisplayModels();
            OnPropertyChanged(nameof(DayBtnColor));
            OnPropertyChanged(nameof(WeekBtnColor));
            OnPropertyChanged(nameof(MonthBtnColor));
        }

        private void UpdateStatisticsHeight()
        {
            var count = StatisticsDisplayModels.Count();
            StatisticsHeight = ((count / 2) + (count % 2)) * StatsBlockHeight;
        }

        private void OnPersonalDataChanged()
        {
            StatisticsModelByFilter = DataRefresher.StatisticsModelByFilter;
            AchievementModels = DataRefresher.AchievementModels;
            UserInfo = DataRefresher.UserInfo;
        }

        private void UpdateAchievementsHeight() => AchievementsHeight = AchievementDisplayModels.Count() * AchievementBlockHeight;
    }
}
