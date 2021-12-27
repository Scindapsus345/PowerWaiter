using System;
using System.Collections.Generic;
using System.Text;

namespace PowerWaiters.Models
{
    class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public int Scores { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
