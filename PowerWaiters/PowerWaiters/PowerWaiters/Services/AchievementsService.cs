using PowerWaiters.Models;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class AchievementsService
    {
        static public IEnumerable<AchievementModel> GetAchievements()
        {
            return new List<AchievementModel>
            {
                new AchievementModel
                {
                    Name = "Fisher",
                    Description = "Sell 10 fishes",
                    IconUrl = "https://yt3.ggpht.com/a/AATXAJwVmCcsA1IhkdWb63_FwfedCcSS2IS0aLggpA=s900-c-k-c0xffffffff-no-rj-mo",
                    Progress = 10,
                    Purpose = 10,
                    Level = 1
                },
                new AchievementModel{
                    Name = "Lox",
                    Description = "Be late 20 times",
                    IconUrl = "https://yt3.ggpht.com/a/AATXAJwVmCcsA1IhkdWb63_FwfedCcSS2IS0aLggpA=s900-c-k-c0xffffffff-no-rj-mo",
                    Progress = 10,
                    Purpose = 20,
                    Level = 10
                },
                new AchievementModel(),
                new AchievementModel()
            };
        }
    }
}
