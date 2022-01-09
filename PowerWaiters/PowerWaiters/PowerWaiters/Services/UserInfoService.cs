using PowerWaiters.Models;
using PowerWaiters.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace PowerWaiters.Services
{
    static class UserInfoService
    {
        private static UserInfo formatErrorData = new UserInfo
        {
            FirstName = "Игорь",
            LastName = "Голдберг",
            Post = "Официант",
            TotalScores = 3672,
            EmploymentDate = "27.02.2001"
        };

        public static async Task<UserInfo> GetUserInfo()
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
                    return null;
                }
            }
            return await JsonDeserializeHelper.TryDeserialise(response, formatErrorData);
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}/info";
    }
}
