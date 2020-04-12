using System;
using System.Linq;

namespace ImageProcessing.App.Common.Extensions.TypeExtensions
{
    /// <summary>
    /// Extension methods for a <see cref="Type"> class.
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Get the specified <typeparamref name="TValue"/> from an <typeparamref name="TAttribute"/> 
        /// defined on a <see cref="Type"/>.
        /// <para>Where the <typeparamref name="TAttribute"/> is an <see cref="Attribute"/>. </para>
        /// </summary>
        public static TValue GetAttributeValue<TAttribute, TValue>
            (this Type type, Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            if(type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (valueSelector is null)
            {
                throw new ArgumentNullException(nameof(valueSelector));
            }

            var att = type.GetCustomAttributes(typeof(TAttribute), true)
                          .FirstOrDefault() as TAttribute;

            if (att != null)
            {
                return valueSelector(att);
            }

            return default(TValue);
        }

        /// <summary>
        /// Check whether the specified <see cref="Type"/>
        /// contains a <typeparamref name="TAttribute"/>.
        /// <para>Where the <typeparamref name="TAttribute"/> is an <see cref="Attribute"/>. </para>
        /// </summary>
        public static bool HasAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
            => type?.IsDefined(typeof(TAttribute), false) ?? throw new ArgumentNullException(nameof(type));
    }
}
