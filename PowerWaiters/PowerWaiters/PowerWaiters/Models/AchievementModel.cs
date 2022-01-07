using PowerWaiters.Extensions;

namespace PowerWaiters.Models
{
    class AchievementModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int Purpose { get; set; }
        public int Progress { get; set; }
        public int Level { get; set; }
        public int Prize { get; set; }

        public AchievementDisplayModel ConvertToDisplayModel() => new AchievementDisplayModel
        {
            Name = Name,
            Description = Description,
            IconUrl = IconUrl,
            ProgressString = $"{Progress.ToFriendlyString()}",
            LevelString = $"LEVEL {Level}",
            BackgroundImageName = GetBackgroundImageNameByLevel(),
            OfPurposeString = $"/{Purpose.ToFriendlyString()}",
            ProgressPercents = ((int)(((double)Progress)/Purpose * 100)).ToString()
        };

        private string GetBackgroundImageNameByLevel()
        {
            switch (Level)
            {
                case 1:
                    return "bronze_achievements";
                case 2:
                    return "silver_achievements";
                default:
                    return "gold_achievements";
            }
        }
    } 
}
