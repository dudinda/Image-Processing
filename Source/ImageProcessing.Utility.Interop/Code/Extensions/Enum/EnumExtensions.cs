using System;
using System.ComponentModel;

namespace ImageProcessing.Utility.Interop.Code.Extensions
{
    internal static class EnumExtensions
    {
        /// <summary>
        /// Get a description of the <see cref="Enum"/> value.
        /// </summary>
        /// <typeparam name="TEnum">An enumerated type.</typeparam>
        /// <param name="value">The source value.</param>
        internal static string GetDescription<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? ((DescriptionAttribute)attributes[0]).Description : null;
        }
    }
}
