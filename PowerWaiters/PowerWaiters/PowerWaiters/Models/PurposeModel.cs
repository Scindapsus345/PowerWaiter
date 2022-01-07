using PowerWaiters.Extensions;
using System;

namespace PowerWaiters.Models
{
    class PurposeModel
    {
        public string Name { get; set; }
        public int Prize { get; set; }
        public int Purpose { get; set; }
        public int Progress { get; set; }
        public string Deadline { get; set; }
        public int Percentages => (int)(((double)Progress) / Purpose * 100);

        public PurposeDisplayModel ConvertToDisplayModel() => new PurposeDisplayModel
        {
            Name = Name,
            PrizeString = Prize.ToFriendlyString(),
            PurposeString = Purpose.ToFriendlyString(),
            ProgressString = Progress.ToFriendlyString(),
            Deadline = Deadline,
            Percentages = ((int)(((double)Progress) / Purpose * 100)).ToString()
        };
    }
}
