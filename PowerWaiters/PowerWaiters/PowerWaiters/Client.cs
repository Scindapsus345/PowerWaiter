using System.Net.Http;

namespace PowerWaiters
{
    public static class Client
    {
        public static string BaseServerAddress => "https://waitersproject.herokuapp.com";
        public static HttpClient HttpClient { get; }
    }
}
