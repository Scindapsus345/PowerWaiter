using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PowerWaiters.Helpers;
using PowerWaiters.Models;

namespace PowerWaiters.Services
{
    static class LoginService
    {
        public static bool TryLogin(LoginModel loginModel)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var json = JsonConvert.SerializeObject(loginModel, jsonSettings);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = Client.HttpClient.GetAsync(RequestUrl(Client.UserId)).Result;
            if (!response.IsSuccessStatusCode)
                return false;
            SaveAuthData(response);
            return true;
        }

        private static void SaveAuthData(HttpResponseMessage response)
        {
            var authData = JsonDeserializeHelper.TryDeserialise<AuthModel>(response, null).Result;
            App.Current.Properties["UserId"] = authData.UserId;
            App.Current.Properties["AccessToken"] = authData.AccessToken;
            Client.LoadAuthDataFromMemory();
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/allMissions";
    }
}
