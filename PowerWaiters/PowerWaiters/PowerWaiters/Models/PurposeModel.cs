using PowerWaiters.Extensions;
using PowerWaiters.Helpers;

namespace PowerWaiters.Models
{
    class PurposeModel
    {
        public string Name { get; set; }
        public int Prize { get; set; }
        public int Purpose { get; set; }
        public int Progress { get; set; }
        public string Deadline { get; set; }

        public PurposeDisplayModel ConvertToDisplayModel() => new PurposeDisplayModel
        {
            Name = Name,
            PrizeString = Prize.ToFriendlyString(),
            PurposeString = Purpose.ToFriendlyString(),
            ProgressString = Progress.ToFriendlyString(),
            Deadline = Deadline,
            Percentages = PercentHelper.GetPercentages(Progress, Purpose).ToString()
        };
    }
}
