using PowerWaiters.Models;
using System;

namespace PowerWaiters.Helpers
{
    public static class StatisticsTypeToQueryConverter
    {
        public static string Convert(StatisticsType type)
        {
            switch (type)
            {
                case StatisticsType.Xp:
                    return "type=xp";
                case StatisticsType.AverageCheque:
                    return "type=averagecheque";
                case StatisticsType.Golist:
                    return "type=golist";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
