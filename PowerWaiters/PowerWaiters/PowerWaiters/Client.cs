using PowerWaiters.Helpers;
using PowerWaiters.Views;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PowerWaiters
{
    public static class Client
    {
        public static string BaseServerAddress => "https://waitersproject.herokuapp.com";
        public static HttpClient HttpClient { get; } = new HttpClient();
        public static int UserId { get; set; } = -1;
        public static bool IsBlocked { get; set; }

        public static void LoadAuthDataFromMemory()
        {
            SetUserId();
            SetAuthorizationHeader();
        }

        public static bool TryGet<T>(string requestUrl, out T value)
        {
            value = default(T);
            if (IsBlocked)
                return false;
            if (UserId == -1)
            {
                IsBlocked = true;
                App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                return false;
            }
            var response = HttpClient.GetAsync(requestUrl).Result;
            if (!response.IsSuccessStatusCode)
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    IsBlocked = true;
                    App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    return false;
                }
                else
                    return false;
            value = JsonDeserializeHelper.TryDeserialise<T>(response).Result;
            return true;
        }

        public static bool TryPost<T>(string requestUrl, HttpContent body, out T value, bool isLogin = false)
        {
            value = default(T);
            if (!isLogin)
            {
                if (IsBlocked)
                    return false;
                if (UserId == -1)
                {
                    IsBlocked = true;
                    App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    return false;
                }
            }
            var response = HttpClient.PostAsync(requestUrl, body).Result;
            if (!response.IsSuccessStatusCode)
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    if (!isLogin)
                    {
                        IsBlocked = true;
                        App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                    return false;
                }
                else
                    return false;
            value = JsonDeserializeHelper.TryDeserialise<T>(response).Result;
            return true;
        }

        private static void SetUserId() => UserId = (int) App.Current.Properties["UserId"];

        private static void SetAuthorizationHeader()
        {
            var accessToken = (string)App.Current.Properties["AccessToken"];
            HttpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(accessToken);
        }
    }
}
