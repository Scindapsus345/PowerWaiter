using System;
using System.Collections.Generic;
using System.Text;

namespace PowerWaiters.Models
{
    class AchievementDisplayModel
    {
        public string BackgroundImageName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int Prize { get; set; }
        public string ProgressString { get; set; }
        public string LevelString { get; set; }
    }
}
