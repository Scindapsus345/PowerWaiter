using System;
using System.Collections.Generic;
using System.Text;

namespace PowerWaiters.Models
{
    class LeaderboardItem
    {
        public string Name { get; set; }
        public int Scores { get; set; }
        public bool IsCurrentUser { get; set; }
        public string Number { get; set; }
        public string BorderColor { get; set; }
        public string BackgroundColor { get; set; }
    }
}
