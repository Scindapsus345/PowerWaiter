using System;
using System.Collections.Generic;
using System.Text;

namespace PowerWaiters.Models
{
    public class StatisticsModel
    {
        public int? ServedGuests { get; set; }
        public int? DailyRevenue { get; set; }
        public int? DishesByGoList { get; set; }
        public int? OrdersClosed { get; set; }
        public int? DigitizedGuests { get; set; }
    }
}
