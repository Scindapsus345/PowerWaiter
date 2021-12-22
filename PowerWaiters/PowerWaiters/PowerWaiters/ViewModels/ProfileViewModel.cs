using PowerWaiters.Models;
using PowerWaiters.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class ProfileViewModel : BindableObject
    {
        public StatisticsModel StatisticsModel = StatisticsService.GetStatistics(StatisticsTimeSpan.Day);

        private List<StatisticsDisplayModel> statisticsDisplayModels = new List<StatisticsDisplayModel>();
        public List<StatisticsDisplayModel> StatisticsDisplayModels
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

        private IEnumerable<AchievementModel> achievementModels;
        public IEnumerable<AchievementModel> AchievementModels
        {
            get => achievementModels;
            set
            {
                if (value == achievementModels)
                    return;
                achievementModels = value;
                UpdateStatisticsHeight();
                OnPropertyChanged();
            }
        }

        public ProfileViewModel()
        {
            StatisticsDisplayModels = GetStatisticDisplayModels(StatisticsModel);
            AchievementModels = AchievementsService.GetAchievements();
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
            var count = statisticsDisplayModels.Count;
            StatisticsHeight = ((count / 2) + (count % 2)) * statsBlockHeight;
        }

    }
}
