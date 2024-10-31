using System.Reflection;

namespace VYG.Core.ExtensionMethods
{
    public static class AttributeExtensions
    {
        public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return Attribute.IsDefined(type, typeof(TAttribute));
        }

        public static TAttribute GetAttributeValue<TAttribute>(this object obj, string propertyName) where TAttribute : Attribute
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property name cannot be null or empty.", nameof(propertyName));

            PropertyInfo property = obj.GetType().GetProperty(propertyName);
            if (property == null) throw new ArgumentException($"Property '{propertyName}' not found on type '{obj.GetType()}'.", nameof(propertyName));

            var attribute = property.GetCustomAttribute<TAttribute>();
            return attribute;
        }

        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            return (T)type.GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }
    }
}
