using PowerWaiters.Models;
using PowerWaiters.Helpers;

namespace PowerWaiters.Services
{
    static class UserInfoService
    {
        public static UserInfo GetUserInfo()
        {
            if (Client.TryGet(RequestUrl(Client.UserId), out UserInfo userInfo))
                return userInfo;
            return new UserInfo();
        }

        private static string RequestUrl(int userId) => $"{Client.BaseServerAddress}/waiters/{userId}";
    }
}
