using System;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessing.App.Domain.Code.Extensions
{
    /// <summary>
    /// Extension methods for a <see cref="Enum"/> value.
    /// </summary>
    public static class EnumExtensions
    {
        extension<TEnum>(string value) where TEnum : Enum
        {
            /// <summary>
            /// Get a <see cref="Enum"/> value by the name.
            /// </summary>
            /// <typeparam name="TEnum">An enumerated type.</typeparam>
            /// <param name="value">The source value.</param>
            public TEnum GetEnumValueByName() => (TEnum)Enum.Parse(typeof(TEnum), value);

            /// <summary>
            /// Get a <see cref="Enum" /> value from the specified description value.
            /// </summary>
            /// <typeparam name="TEnum">An enumerated type.</typeparam>
            /// <param name="description">The source value.</param>
            public TEnum GetValueFromDescription()
            {
                var type = typeof(TEnum);

                foreach (var field in type.GetFields())
                {
                    var attribute = Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute)) as DescriptionAttribute;

                    if (attribute != null)
                    {
                        if (attribute.Description == value)
                        {
                            return (TEnum)field.GetValue(null);
                        }
                    }
                    else
                    {
                        if (field.Name == value)
                        {
                            return (TEnum)field.GetValue(null);
                        }
                    }
                }

                throw new ArgumentException(value, nameof(value));
            }
        }

        extension(int value)
        {
            /// <summary>
            /// Get a <see cref="Enum"/> value by an integer.
            /// </summary>
            /// <typeparam name="TEnum">An enumerated type.</typeparam>
            /// <param name="value">The source value.</param>
            public TEnum GetEnumValueByInt<TEnum>()
                where TEnum : Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        }

        extension<TEnum>(TEnum value) where TEnum : Enum
        {
            /// <summary>
            /// Get a description of the <see cref="Enum"/> value.
            /// </summary>
            /// <typeparam name="TEnum">An enumerated type.</typeparam>
            /// <param name="value">The source value.</param>
            public string? GetDescription() 
            {
                var type = value.GetType();
                var memInfo = type.GetMember(value.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                return (attributes.Length > 0) ? ((DescriptionAttribute)attributes[0]).Description : null;
            }
        }

        /// <summary>
        /// Get all values from the specified <typeparamref name="TEnum"/>
        /// except for the default value.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="enumeration">The source enumeration.</param>
        /// <returns>All values except for the default.</returns>
        public static TEnum[] GetAllEnumValues<TEnum>()
            => Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
    }
}
