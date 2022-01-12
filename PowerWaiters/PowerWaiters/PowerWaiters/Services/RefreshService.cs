using Newtonsoft.Json;
using PowerWaiters.Helpers;
using PowerWaiters.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace PowerWaiters.Services
{
    static class RefreshService
    {
        public static RefreshStatus GetRefreshStatus(LastUpdateDates lastUpdateDates)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "dd.MM.yyyy HH:mm:ss"; //try .fffZ too
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var json = JsonConvert.SerializeObject(lastUpdateDates, jsonSettings);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = Client.HttpClient.PostAsync(RequestUrl(Client.UserId), data).Result;
            if (!response.IsSuccessStatusCode)
                    return null;
            return JsonDeserializeHelper.TryDeserialise(response, new RefreshStatus()).Result;
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/polling/{userId}";
    }
}
