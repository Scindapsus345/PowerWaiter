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
        public string ProgressString => $"{Progress} / {Purpose}";
        public string LevelString => $"Уровень: {Level}";

        public AchievementDisplayModel ConvertToDisplayModel() => new AchievementDisplayModel
        {
            Name = Name,
            Description = Description,
            IconUrl = IconUrl,
            Prize = Prize,
            ProgressString = $"{Progress}/{Purpose}",
            LevelString = $"LEVEL {Level}",
            BackgroundImageName = GetBackgroundImageNameByLevel()
        };

        private string GetBackgroundImageNameByLevel()
        {
            switch (Level)
            {
                case 1:
                    return "bronze_achievement";
                case 2:
                    return "silver_achievement";
                default:
                    return "gold_achievement";
            }
        }
    } 
}
