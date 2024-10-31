using System.ComponentModel;
using System.Reflection;

namespace VYG.Core.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            return Enum.TryParse(value, true, out T result) ? result : defaultValue;
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field?.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static List<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static bool HasFlagFast<T>(this T value, T flag) where T : Enum
        {
            var intValue = Convert.ToInt64(value);
            var intFlag = Convert.ToInt64(flag);
            return (intValue & intFlag) == intFlag;
        }

        public static Dictionary<int, string> ToDictionary<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .ToDictionary(e => Convert.ToInt32(e), e => e.GetDescription());
        }

    }
}
