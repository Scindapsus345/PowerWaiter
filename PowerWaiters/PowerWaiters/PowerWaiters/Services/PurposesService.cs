using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class PurposesService
    {
        public static IEnumerable<PurposeModel> GetPurposes()
        {
            if (Client.TryGet(RequestUrl(Client.UserId), out PurposeModel[] models))
                return models;
            return new List<PurposeModel>();
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/allMissions";
    }
}
