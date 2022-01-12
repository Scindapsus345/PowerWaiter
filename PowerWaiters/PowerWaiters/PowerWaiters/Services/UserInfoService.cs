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
            Position = "Официант",
            TotalScores = 3672,
            EmploymentDate = "27.02.2001"
        };

        public static UserInfo GetUserInfo()
        {
            var response = Client.HttpClient.GetAsync(RequestUrl(Client.UserId)).Result;
            if (!response.IsSuccessStatusCode)
                return null; 
            return JsonDeserializeHelper.TryDeserialise(response, formatErrorData).Result;
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}";
    }
}
