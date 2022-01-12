using System.Collections.Generic;

namespace PowerWaiters.Models
{
    class RestourantInfo
    {
        public string Name { get; set; }
        public IEnumerable<RestourantStatsModel> Statistics { get; set; }
    }
}
