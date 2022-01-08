using PowerWaiters.Extensions;
using PowerWaiters.Helpers;

namespace PowerWaiters.Models
{
    class RestourantStatsModel
    {
        public string Name { get; set; }
        public int Purpose { get; set; }
        public int Progress { get; set; }
        public string Deadline { get; set; }

        public RestourantStatsDisplayModel ConvertToDisplayModel() => new RestourantStatsDisplayModel
        {
            Name = Name,
            PurposeString = Purpose.ToFriendlyString(),
            ProgressString = Progress.ToFriendlyString(),
            Deadline = Deadline,
            Percentages = PercentHelper.GetPercentages(Progress, Purpose).ToString()
        };
    }
}
