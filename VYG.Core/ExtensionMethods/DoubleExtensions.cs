namespace VYG.Core.ExtensionMethods
{
    public static class DoubleExtensions
    {
        public static double ToDouble(this string value, double defaultValue = 0.0)
        {
            return double.TryParse(value, out var result) ? result : defaultValue;
        }

        public static double ToFixed(this object value, int decimalPlaces)
        {
            return Math.Round(Convert.ToDouble(value), decimalPlaces);
        }
    }
}
