using Newtonsoft.Json;
using PowerWaiters.Helpers;
using PowerWaiters.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PowerWaiters.Services
{
    static class RefreshService
    {
        public static async Task<RefreshStatus> GetRefreshStatus(LastUpdateDates lastUpdateDates)
        {
            return new RefreshStatus
            {
                Leaderboard = true,
                Personal = true,
                Restourant = true
            };
            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(lastUpdateDates);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = Client.HttpClient)
            {
                try
                {
                    response = await client.PostAsync(RequestUrl(2), data);
                }
                catch
                {
                    return null;
                }
            }
            return await JsonDeserializeHelper.TryDeserialise<RefreshStatus>(response, null);
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/refresh";
    }
}
