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
                    IconUrl = "https://imgcdn.wangyeyixia.com/aHR0cDovL3BuZ2ltZy5jb20vdXBsb2Fkcy9jcm93bi9jcm93bl9QTkcyMzg2OC5wbmc%3D.png?w=400",
                    Prize = 400,
                    Progress = 78,
                    Purpose = 100,
                    Level = 7
                },
                new AchievementModel{
                    Name = "Царь горы",
                    Description = "Пробыть в топ-1 15 дней",
                    IconUrl = "https://imgcdn.wangyeyixia.com/aHR0cDovL3BuZ2ltZy5jb20vdXBsb2Fkcy9jcm93bi9jcm93bl9QTkcyMzg2OC5wbmc%3D.png?w=400",
                    Progress = 13,
                    Prize = 400,
                    Purpose = 15,
                    Level = 3
                },
                new AchievementModel
                {
                    Name = "Коллекционер",
                    Description = "Суммарный уровень достижений - 15",
                    IconUrl = "https://imgcdn.wangyeyixia.com/aHR0cDovL3BuZ2ltZy5jb20vdXBsb2Fkcy9jcm93bi9jcm93bl9QTkcyMzg2OC5wbmc%3D.png?w=400",
                    Progress = 12,
                    Prize = 400,
                    Purpose = 15,
                    Level = 1
                },
                new AchievementModel
                {
                    Name = "Ученик",
                    Description = "Проработать в ресторане 1 месяц",
                    IconUrl = "https://imgcdn.wangyeyixia.com/aHR0cDovL3BuZ2ltZy5jb20vdXBsb2Fkcy9jcm93bi9jcm93bl9QTkcyMzg2OC5wbmc%3D.png?w=400",
                    Progress = 27,
                    Prize = 400,
                    Purpose = 30,
                    Level = 2
                }
            };
        }
    }
}
