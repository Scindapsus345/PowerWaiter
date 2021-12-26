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
        public bool Completed => Purpose == Progress;
        public string ProgressString => Completed ? "Получена" : $"{Progress} / {Purpose}";
        public string BorderColor => Completed ? "Black" : "Transparent";
        public string TextColor => Completed ? "Black" : "#999999";
        public string LevelString => $"Уровень: {Level}";
        public string BackgroundColor => Completed ? "#F0FFF0" : "#F1F1F1";
    } 
}
