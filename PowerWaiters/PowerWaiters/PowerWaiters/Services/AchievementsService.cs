using PowerWaiters.Helpers;
using PowerWaiters.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PowerWaiters.Services
{
    static class AchievementsService
    {
        private static List<AchievementModel> formatErrorData = new List<AchievementModel>
            {
                new AchievementModel{
                    Name = "ОШИБКА ФОРМАТА",
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

        public static async Task<IEnumerable<AchievementModel>> GetAchievements()
        {
            return formatErrorData;
            HttpResponseMessage response;
            using (var client = Client.HttpClient)
            {
                response = await client.GetAsync(RequestUrl(2));
                if (!response.IsSuccessStatusCode)
                    return new List<AchievementModel>();
            }
            return await JsonDeserializeHelper.TryDeserialise(response, formatErrorData);
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/allAchievements";
    }
}
