namespace VYG.Core.ExtensionMethods
{
    public static class IntegerExtensions
    {

        public static int ToInt(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out var result) ? result : defaultValue;
        }

        public static bool IsGreaterThanZero(this int value)
        {
            return value > 0;
        }
    }
}
