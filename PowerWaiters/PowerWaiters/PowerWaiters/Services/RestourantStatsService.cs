using PowerWaiters.Models;

namespace PowerWaiters.Services
{
    static class RestourantStatsService
    {
        public static RestourantStatsModel GetRestourantStats()
        {
            return new RestourantStatsModel
            {
                Name = "Italian Pizza",
                GuestsCount = 555,
                Revenue = 170539
            };
        }
    }
}
