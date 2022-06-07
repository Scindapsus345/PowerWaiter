using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerWaiters.Models;
using PowerWaiters.Services;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class AchievementsViewModel : BindableObject
    {
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
                OnPropertyChanged();
            }
        }

        public AchievementsViewModel()
        {
            AchievementModels = AchievementsService.GetAchievements();
        }
    }
}
