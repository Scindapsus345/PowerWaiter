using PowerWaiters.Helpers;
using PowerWaiters.Models;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class AchievementsService
    {
        public static IEnumerable<AchievementModel> GetAchievements()
        {
            if (Client.TryGet(RequestUrl(Client.UserId), out AchievementModel[] models))
                return models;
            return new List<AchievementModel>();
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/allAchievements";
    }
}
