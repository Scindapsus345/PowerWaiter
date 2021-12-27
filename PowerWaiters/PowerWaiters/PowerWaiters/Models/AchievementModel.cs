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
        public string ProgressString => $"{Progress} / {Purpose}";
        public string LevelString => $"Уровень: {Level}";
    } 
}
