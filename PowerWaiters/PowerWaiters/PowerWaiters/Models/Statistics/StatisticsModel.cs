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
            statisticsDisplayModels.Add(new StatisticsDisplayModel("Рейтинг", Rating.ToString(), "rating_icon"));
            if (DailyRevenue != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Выручка", DailyRevenue.Value.ToString(), "cash_icon.png"));
            if (DishesByGoList != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Блюд по Go листу", DishesByGoList.Value.ToString(), "golist_icon.png"));
            if (OrdersClosed != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Заказов закрыто", OrdersClosed.Value.ToString(), "orders_icon.png"));
            if (DigitizedGuests != null)
                statisticsDisplayModels.Add(new StatisticsDisplayModel("Оцифрованные гости", DigitizedGuests.Value.ToString(), "checkin_icon.png"));
            return statisticsDisplayModels;
        }
    }
}
