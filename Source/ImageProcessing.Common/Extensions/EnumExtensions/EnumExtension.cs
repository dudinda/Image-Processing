using System;
using System.ComponentModel;

namespace ImageProcessing.Common.Extensions.EnumExtensions
{
    /// <summary>
    /// Extension methods for <see cref="enum"> value.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Get a enum value by name.
        /// </summary>
        /// <typeparam name="T">An enumerated type.</typeparam>
        /// <param name="value">The source value.</param>
        /// <returns></returns>
        public static TEnum GetEnumValueByName<TEnum>(this string value)
            where TEnum : struct
            => (TEnum)Enum.Parse(typeof(TEnum), value);


        public static string GetDescription<TEnum>(this TEnum value) 
            where TEnum : struct
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(TEnum), false);
            return (attributes.Length > 0) ? ((TEnum)attributes[0]).ToString() : null;
        }

        public static TEnum GetValueFromDescription<TEnum>(this string description)
            where TEnum : struct
        {
            var type = typeof(TEnum);

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
                        return (TEnum)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
    }
}
