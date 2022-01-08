using System;
using System.Collections.Generic;
using System.Text;

namespace PowerWaiters.Models
{
    class LeaderboardItem
    {
        public string Name { get; set; }
        public string ScoresString { get; set; }
        public bool IsCurrentUser { get; set; }
        public string Number { get; set; }
        public string CupName { get; set; }
        public string BackgroundColor { get; set; }
    }
}
