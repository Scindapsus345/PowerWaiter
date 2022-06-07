using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            if (Client.TryPost(RequestUrl(), data, out AuthModel authData, true))
            {
                SaveAuthData(authData);
                return true;
            }
            return false;
        }

        private static void SaveAuthData(AuthModel authData)
        {
            //App.Current.Properties["UserId"] = authData.UserId;
            //App.Current.Properties["AccessToken"] = authData.AccessToken;
            Client.HttpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authData.Token);
            Client.UserId = authData.IdWaiter;
            //Client.LoadAuthDataFromMemory();
        }

        private static string RequestUrl() => $"{Client.BaseServerAddress}/api/auth/waiter";
    }
}
