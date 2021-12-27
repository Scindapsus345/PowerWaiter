using System;

namespace PowerWaiters.Models
{
    class PurposeModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Prize { get; set; }
        public int Purpose { get; set; }
        public int Progress { get; set; }
        public DateTime Deadline { get; set; }
        public string DeadlineString => $"До {Deadline.ToShortDateString()}";
        public bool Completed => Progress >= Purpose;
        public string ProgressString => Completed ? $"Достигнута {Progress} / {Purpose}" : $"{Progress} / {Purpose}";
        public string BorderColor => Completed ? "Black" : "#C4C4C4";
        public string ProgressTextColor => Completed ? "ForestGreen" : "Black";
        public string BackgroundColor => Completed ? "#F0FFF0" : "#F1F1F1";
    }
}
