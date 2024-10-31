namespace VYG.Core.ExtensionMethods
{
    public static class FloatExtensions
    {
        public static float ToFloat(this string value, float defaultValue = 0.0f)
        {
            return float.TryParse(value, out var result) ? result : defaultValue;
        }

        public static float ToFixed(this object value, int decimalPlaces)
        {
            return (float)Math.Round(Convert.ToSingle(value), decimalPlaces);
        }
    }
}
