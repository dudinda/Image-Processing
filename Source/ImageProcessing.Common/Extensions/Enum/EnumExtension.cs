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
        /// Get a <see cref="Enum"/> value by the name.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="value">The source value.</param>
        public static TEnum GetEnumValueByName<TEnum>(this string value)
            where TEnum : Enum => (TEnum)Enum.Parse(typeof(TEnum), value);

        /// <summary>
        /// Get a <see cref="Enum"/> value by an integer.
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

        /// <summary>
        /// Partition the specified <typeparamref name="TEnum"/> over
        /// the <paramref name="partition"/>. Returns the
        /// specified <typeparamref name="TCallOut"/> from a <paramref name="callback"/>.
        /// </summary>
        public static TOutResult PartitionOver<TEnum, TOutResult>
            (this TEnum src, (TEnum from, TEnum to) partition, Func<TOutResult> callback)
            where TEnum : Enum
        {
            var (from, to) = (Convert.ToInt32(partition.from), Convert.ToInt32(partition.to));
            var srcInt = Convert.ToInt32(src);

            var isInPartition
                = Enum.GetValues(typeof(TEnum))
                       .Cast<int>()
                       .Where(val => val >= from && val <= to)
                       .Any(val => val.Equals(srcInt));

            if (isInPartition)
            {
                return callback();
            }

            throw new NotImplementedException(nameof(src));
        }

        /// <summary>
        /// Get a <see cref="Enum" /> value from the specified description value.
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

        /// <summary>
        /// Get all values from the specified <typeparamref name="TEnum"/>
        /// except for the default value.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="enumeration">The source enumeration.</param>
        /// <returns>All values except for the default.</returns>
        public static TEnum[] GetEnumValuesExceptDefault<TEnum>(this TEnum enumeration)
        { 
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Where(e => !EqualityComparer<TEnum>.Default.Equals(e, default(TEnum)))
                       .ToArray();
        }
    }
}
