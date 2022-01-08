using PowerWaiters.Extensions;
using System.Collections.Generic;

namespace PowerWaiters.Models
{
    public class StatisticsModel
    {
        public int Rating { get; set; }
        public int? DailyRevenue { get; set; }
        public int? DishesByGoList { get; set; }
        public int? OrdersClosed { get; set; }
        public int? DigitizedGuests { get; set; }

        public List<StatisticsDisplayModel> ConvertToStatisticsDisplayModels()
        {
            var statisticsDisplayModels = new List<StatisticsDisplayModel>();
            statisticsDisplayModels.Add(new StatisticsDisplayModel("Рейтинг", Rating.ToXPString(), "rating_icon"));
            if (DailyRevenue != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Выручка", DailyRevenue.Value.ToCurrencyString(), "cash_icon.png"));
            if (DishesByGoList != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Блюд по Go листу", DishesByGoList.Value.ToFriendlyString(), "golist_icon.png"));
            if (OrdersClosed != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Заказов закрыто", OrdersClosed.Value.ToFriendlyString(), "orders_icon.png"));
            if (DigitizedGuests != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Оцифрованные гости", DigitizedGuests.Value.ToFriendlyString(), "checkin_icon.png"));
            return statisticsDisplayModels;
        }
    }
}
