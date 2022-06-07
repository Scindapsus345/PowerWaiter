using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace PowerWaiters.Helpers
{
    public static class JsonDeserializeHelper
    {
        public static async Task<T> TryDeserialise<T>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
