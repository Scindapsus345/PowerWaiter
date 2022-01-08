namespace PowerWaiters.Helpers
{
    static class PercentHelper
    {
        public static int GetPercentages(double progress, double purpose) => (int)(progress / purpose * 100);
    }
}
