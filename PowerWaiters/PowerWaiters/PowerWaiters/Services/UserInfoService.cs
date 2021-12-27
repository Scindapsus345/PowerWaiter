using PowerWaiters.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerWaiters.Services
{
    static class UserInfoService
    {
        public static UserInfo GetUserInfo() => new UserInfo
        {
            FirstName = "Игорь",
            LastName = "Голдберг",
            Description = "Официант",
            Scores = 3672,
            AvatarUrl = "https://www.hotelberlin-sindelfingen.de/wp-content/uploads/sites/4/2015/08/Kellner.jpg"
        };
    }
}
