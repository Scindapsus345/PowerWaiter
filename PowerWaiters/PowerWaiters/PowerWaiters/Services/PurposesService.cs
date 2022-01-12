using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class PurposesService
    {
        private static PurposeModel[] formatErrorData =  {
            new PurposeModel
            {
                Name = "ОШИБКА ФОРМАТА",
                Prize = 3500,
                Progress = 891563,
                Purpose = 1000000,
                Deadline = "27.02.2023"
            },
            new PurposeModel
            {
                Name = "Обслуженные гости",
                Prize = 2000,
                Progress = 2699,
                Purpose = 2000,
                Deadline = "12.05.2023"
            }
        };

        public static IEnumerable<PurposeModel> GetPurposes()
        {

            var response = Client.HttpClient.GetAsync(RequestUrl(Client.UserId)).Result;
            if (!response.IsSuccessStatusCode)
                return new List<PurposeModel>();
            return JsonDeserializeHelper.TryDeserialise(response, formatErrorData).Result;
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/allMissions";
    }
}
