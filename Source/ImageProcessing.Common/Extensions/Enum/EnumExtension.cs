using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessing.Common.Extensions.EnumExtensions
{
    /// <summary>
    /// Extension methods for a <see cref="Enum"/> value.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Get a <see cref="Enum"/> value by name.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="value">The source value.</param>
        public static TEnum GetEnumValueByName<TEnum>(this string value)
            where TEnum : Enum => (TEnum)Enum.Parse(typeof(TEnum), value);

        /// <summary>
        /// Get a <see cref="Enum"/> value by name.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="value">The source value.</param>
        public static TEnum GetEnumValueByInt<TEnum>(this int value)
            where TEnum : Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);

        /// <summary>
        /// Get a description of the <see cref="Enum"/> value.
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

        public static TCallOut PartitionOver<TEnum, TCallOut>
            (this TEnum src, (TEnum from, TEnum to) partition, Func<TCallOut> callback)
            where TEnum : Enum
        {
            var (to, from) = (Convert.ToInt32(partition.from), Convert.ToInt32(partition.to));

            var isInPartition
                = Enum.GetValues(typeof(TEnum))
                       .Cast<int>()
                       .Where(val => val >= from && val <= to)
                       .Any(val => GetEnumValueByInt<TEnum>(val).Equals(src));

            if(isInPartition)
            {
                return callback();
            }

            throw new NotImplementedException(nameof(src));
        }

        /// <summary>
        /// Get a <see cref="Enum"/ >value from a specified description value.
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
