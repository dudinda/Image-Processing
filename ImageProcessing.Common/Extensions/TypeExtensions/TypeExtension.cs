using System;
using System.Linq;

namespace ImageProcessing.Common.Extensions.TypeExtensions
{
    public static class TypeExtension
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {

            if (valueSelector == null)
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
        {
            return type.IsDefined(typeof(TAttribute), false);
        }

    }
}
