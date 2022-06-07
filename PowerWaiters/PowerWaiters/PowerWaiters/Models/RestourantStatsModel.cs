using PowerWaiters.Extensions;
using PowerWaiters.Helpers;

namespace PowerWaiters.Models
{
    public class RestourantStatsModel
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string IconName { get; set; }
        public bool IsMoney { get; set; }

        public RestourantStatsDisplayModel ConvertToDisplayModel() => new RestourantStatsDisplayModel
        {
            Name = Name,
            AmountString = IsMoney ? Amount.ToCurrencyString() : Amount.ToFriendlyString(),
            IconName = IconName
        };
    }
}
