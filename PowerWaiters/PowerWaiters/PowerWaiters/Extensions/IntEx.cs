namespace PowerWaiters.Extensions
{
    static class IntEx
    {
        public static string ToCurrencyString(this int number)
        {
            return $"{number.ToFriendlyString()} ₽";
        }

        public static string ToXPString(this int number)
        {
            return $"{number.ToFriendlyString()} XP";
        }

        public static string ToFriendlyString(this int number)
        {
            if (number > 1000000)
                return $"{number / 1000000} {number % 1000000 / 1000} {number % 1000}";
            if (number > 1000)
                return $"{number / 1000} {number % 1000}";
            return $"{number}";
        }
    }
}
