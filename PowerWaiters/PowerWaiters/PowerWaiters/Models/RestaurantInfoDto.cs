using System.Collections.Generic;

namespace PowerWaiters.Models
{
    public class RestaurantInfoDto
    {
        public string FirstName { get; set; }
        public int? Revenue { get; set; }
        public int? GoList { get; set; }
        public int? Orders { get; set; }
        public int? AverageCheque { get; set; }

        public RestourantInfo ConvertToRestaurantInfo()
        {
            var stats = new List<RestourantStatsModel>();
            if (Revenue != null)
                stats.Add(new RestourantStatsModel { Name = "Выручка", Amount = Revenue.Value, IconName = "goldbag_icon_mini", IsMoney = true});
            if (AverageCheque != null)
                stats.Add(new RestourantStatsModel { Name = "Средний чек", Amount = AverageCheque.Value, IconName = "cheque_icon_mini", IsMoney = true });
            if (Orders != null)
                stats.Add(new RestourantStatsModel { Name = "Заказов закрыто", Amount = Orders.Value, IconName = "orders_icon_mini", IsMoney = false });
            if (GoList != null)
                stats.Add(new RestourantStatsModel { Name = "Продано блюд дня", Amount = GoList.Value, IconName = "golist_icon_mini", IsMoney = false });
            
            return new RestourantInfo
            {
                Name = FirstName,
                Statistics = stats
            };
        }
    }
}