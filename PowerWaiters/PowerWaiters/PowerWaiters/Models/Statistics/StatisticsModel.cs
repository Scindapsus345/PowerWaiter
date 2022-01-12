using PowerWaiters.Extensions;
using System.Collections.Generic;

namespace PowerWaiters.Models
{
    public class StatisticsModel
    {
        public int Rating { get; set; }
        public int? Revenue { get; set; }
        public int? GoList { get; set; }
        public int? Orders { get; set; }
        public int? Checkins { get; set; }

        public List<StatisticsDisplayModel> ConvertToStatisticsDisplayModels()
        {
            var statisticsDisplayModels = new List<StatisticsDisplayModel>();
            statisticsDisplayModels.Add(new StatisticsDisplayModel("Рейтинг", Rating.ToXPString(), "rating_icon"));
            if (Revenue != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Выручка", Revenue.Value.ToCurrencyString(), "cash_icon.png"));
            if (GoList != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Блюд по Go листу", GoList.Value.ToFriendlyString(), "golist_icon.png"));
            if (Orders != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Заказов закрыто", Orders.Value.ToFriendlyString(), "orders_icon.png"));
            if (Checkins != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Оцифрованные гости", Checkins.Value.ToFriendlyString(), "checkin_icon.png"));
            return statisticsDisplayModels;
        }
    }
}
