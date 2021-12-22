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
