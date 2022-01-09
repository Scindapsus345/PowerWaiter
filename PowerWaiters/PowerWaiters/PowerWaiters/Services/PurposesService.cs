using Newtonsoft.Json;
using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PowerWaiters.Services
{
    static class PurposesService
    {
        private static List<PurposeModel> formatErrorData = new List<PurposeModel>
        {
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

        public static async Task<IEnumerable<PurposeModel>> GetPurposes()
        {
            HttpResponseMessage response;
            using (var client = Client.HttpClient)
            {
                try
                {
                    response = await client.GetAsync(RequestUrl(2));
                }
                catch
                {
                    return new List<PurposeModel>();
                }
            }
            return await JsonDeserializeHelper.TryDeserialise(response, formatErrorData);
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/allMissions";
    }
}
