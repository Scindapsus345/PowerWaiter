using System.Net.Http;
using System.Net.Http.Headers;

namespace PowerWaiters
{
    public static class Client
    {
        public static string BaseServerAddress => "https://waitersproject.herokuapp.com";
        public static HttpClient HttpClient { get; } = new HttpClient();

        public static int UserId { get; private set; }

        public static void LoadAuthDataFromMemory()
        {
            SetUserId();
            SetAuthorizationHeader();
        }

        private static void SetUserId() => UserId = (int) App.Current.Properties["UserId"];

        private static void SetAuthorizationHeader()
        {
            var accessToken = (string)App.Current.Properties["AccessToken"];
            HttpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(accessToken);
        }
    }
}
