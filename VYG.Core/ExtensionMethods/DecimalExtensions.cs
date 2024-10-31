namespace VYG.Core.ExtensionMethods
{
    public static class DecimalExtensions
    {
        public static decimal ToDecimal(this string value, decimal defaultValue = 0.0m)
        {
            return decimal.TryParse(value, out var result) ? result : defaultValue;
        }

        public static decimal ToFixed(this object value, int decimalPlaces)
        {
            return Math.Round(Convert.ToDecimal(value), decimalPlaces);
        }
    }
}
