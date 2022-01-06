namespace PowerWaiters.Models
{
    public class StatisticsDisplayModel
    {
        public string Name { get; }
        public string Count { get; }
        public string IconName { get; }

        public StatisticsDisplayModel(string name, string count, string iconName)
        {
            Name = name;
            Count = count;
            IconName = iconName;
        }
    }
}
