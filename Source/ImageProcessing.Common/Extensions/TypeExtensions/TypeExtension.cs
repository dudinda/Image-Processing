using System;
using System.Linq;

namespace ImageProcessing.Common.Extensions.TypeExtensions
{
    /// <summary>
    /// Extension methods for a <c>Type</c> class
    /// </summary>
    public static class TypeExtension
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
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

        public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
            => type?.IsDefined(typeof(TAttribute), false) ?? throw new ArgumentNullException(nameof(type));
    }
}
