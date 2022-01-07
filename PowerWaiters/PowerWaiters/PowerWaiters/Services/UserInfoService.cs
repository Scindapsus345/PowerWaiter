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
            Post = "Официант",
            TotalScores = 3672,
            EmploymentDate = "27.02.2001"
        };
    }
}
