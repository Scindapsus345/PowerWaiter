using System.Text;

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
            var str = number.ToString();
            var result = new StringBuilder();
            var delay = str[0] == '-' ? str.Length % 3 + 1 : str.Length % 3;
            for (var i = 0; i < str.Length; i++)
            {
                result.Append(str[i]);
                if ((i + 1 - delay) % 3 == 0 && i != str.Length - 1)
                    result.Append(' ');
            }
            return result.ToString();
        }
    }
}
