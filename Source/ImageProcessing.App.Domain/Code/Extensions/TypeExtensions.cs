using System;
using System.Linq;

namespace ImageProcessing.App.Domain.Code.Extensions
{
    /// <summary>
    /// Extension methods for a <see cref="Type"> class.
    /// </summary>
    public static class TypeExtensions
    {
        extension(Type type)
        {
            /// <summary>
            /// Get the specified <typeparamref name="TValue"/> from an <typeparamref name="TAttribute"/> 
            /// defined on a <see cref="Type"/>.
            /// <para>Where the <typeparamref name="TAttribute"/> is an <see cref="Attribute"/>. </para>
            /// </summary>
            public TValue GetAttributeValue<TAttribute, TValue>
                (Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
            {
                var att = type.GetCustomAttributes(typeof(TAttribute), true)
                              .FirstOrDefault() as TAttribute;

                if (att != null)
                {
                    return valueSelector(att);
                }

                return default(TValue)!;
            }

            /// <summary>
            /// Check whether the specified <see cref="Type"/>
            /// contains a <typeparamref name="TAttribute"/>.
            /// <para>Where the <typeparamref name="TAttribute"/> is an <see cref="Attribute"/>. </para>
            /// </summary>
            public bool HasAttribute<TAttribute>()
                where TAttribute : Attribute
                => type.IsDefined(typeof(TAttribute), false);
        }
    }
}
