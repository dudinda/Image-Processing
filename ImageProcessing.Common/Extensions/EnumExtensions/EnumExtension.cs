using System;
using System.ComponentModel;

namespace ImageProcessing.Common.Extensions.EnumExtensions
{
    /// <summary>
    /// Extension methods for a <c>enum</c> value
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Get a enum value by name
        /// </summary>
        /// <typeparam name="T">An enumerated type</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumValueByName<T>(this string value)
            => (T)Enum.Parse(typeof(T), value);
        
        public static T GetValueFromDescription<T>(this string description)
        {
            var type = typeof(T);

            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
    }
}
