using System.Reflection;

namespace VYG.Core.ExtensionMethods
{
    public static class TypeExtensions
    {
        public static bool IsNumericType(this Type type)
        {
            return type == typeof(byte) || type == typeof(sbyte) ||
                   type == typeof(short) || type == typeof(ushort) ||
                   type == typeof(int) || type == typeof(uint) ||
                   type == typeof(long) || type == typeof(ulong) ||
                   type == typeof(float) || type == typeof(double) ||
                   type == typeof(decimal);
        }

        public static Dictionary<string, object> GetPropertyValues<T>(this T obj)
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj));
        }

        public static List<PropertyInfo> GetProperties<T>()
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
        }

        public static void SetPropertyValue<T>(this T obj, string propertyName, object value)
        {
            var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(obj, value);
            }
            else
            {
                throw new ArgumentException($"Property '{propertyName}' not found or not writable.");
            }
        }

    }
}
