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
            Name = "Евгейний",
            Description = "Почему-то думает, что он лучший официант в мире",
            Scores = 12,
            AvatarUrl = "https://sun9-81.userapi.com/impg/c857620/v857620941/1c0e8b/oOAkVZFoco8.jpg?size=450x600&quality=96&sign=42062563927af213d74197b5aa9e4f74&type=album"
        };
    }
}
