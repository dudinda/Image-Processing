using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessing.Common.Extensions.EnumExtensions
{
    /// <summary>
    /// Extension methods for a <see cref="enum"> value.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Get a enum value by name.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="value">The source value.</param>
        public static TEnum GetEnumValueByName<TEnum>(this string value)
            where TEnum : Enum => (TEnum)Enum.Parse(typeof(TEnum), value);

        /// <summary>
        /// Get a description of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="value">The source value.</param>
        public static string GetDescription<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? ((DescriptionAttribute)attributes[0]).Description : null;
        }

        /// <summary>
        /// Get a enum value from a specified description value.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="description>The source value.</param>
        public static TEnum GetValueFromDescription<TEnum>(this string description)
            where TEnum : Enum
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

        public static TEnum[] GetEnumValuesExceptDefault<TEnum>(this TEnum enumeration)
        { 
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Where(e => !EqualityComparer<TEnum>.Default.Equals(e, default(TEnum)))
                       .ToArray();
        }
    }
}
