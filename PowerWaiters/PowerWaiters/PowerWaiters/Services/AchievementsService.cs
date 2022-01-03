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
                new AchievementModel{
                    Name = "Трудоголик",
                    Description = "Выполнить 100 заказов",
                    IconUrl = "https://yt3.ggpht.com/a/AATXAJwVmCcsA1IhkdWb63_FwfedCcSS2IS0aLggpA=s900-c-k-c0xffffffff-no-rj-mo",
                    Progress = 78,
                    Purpose = 100,
                    Level = 7
                },
                new AchievementModel{
                    Name = "Царь горы",
                    Description = "Пробыть в топ-1 15 дней",
                    IconUrl = "https://yt3.ggpht.com/a/AATXAJwVmCcsA1IhkdWb63_FwfedCcSS2IS0aLggpA=s900-c-k-c0xffffffff-no-rj-mo",
                    Progress = 13,
                    Purpose = 15,
                    Level = 3
                },
                new AchievementModel
                {
                    Name = "Коллекционер",
                    Description = "Суммарный уровень достижений - 15",
                    IconUrl = "https://yt3.ggpht.com/a/AATXAJwVmCcsA1IhkdWb63_FwfedCcSS2IS0aLggpA=s900-c-k-c0xffffffff-no-rj-mo",
                    Progress = 12,
                    Purpose = 15,
                    Level = 3
                },
                new AchievementModel
                {
                    Name = "Ученик",
                    Description = "Проработать в ресторане 1 месяц",
                    IconUrl = "https://yt3.ggpht.com/a/AATXAJwVmCcsA1IhkdWb63_FwfedCcSS2IS0aLggpA=s900-c-k-c0xffffffff-no-rj-mo",
                    Progress = 27,
                    Purpose = 30,
                    Level = 2
                }
            };
        }
    }
}
