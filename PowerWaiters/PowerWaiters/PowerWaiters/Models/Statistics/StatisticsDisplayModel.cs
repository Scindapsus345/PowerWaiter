using System;
using System.Collections.Generic;
using System.Text;

namespace PowerWaiters.Models
{
    class StatisticsDisplayModel
    {
        public string Name { get; }
        public string Count { get; }

        public StatisticsDisplayModel(string name, string count)
        {
            Name = name;
            Count = count;
        }
    }
}
