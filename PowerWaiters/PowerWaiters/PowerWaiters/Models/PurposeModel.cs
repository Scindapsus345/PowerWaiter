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
        public bool Completed => Purpose == Progress;
        public string ProgressString => Completed ? "Выполнена" : $"{Progress} / {Purpose}";
        public string BorderColor => Completed ? "Black" : "Transparent";
        public string ProgressTextColor => Completed ? "ForestGreen" : "Black";
        public string BackgroundColor => Completed ? "#F0FFF0" : "#F1F1F1";
    }
}
