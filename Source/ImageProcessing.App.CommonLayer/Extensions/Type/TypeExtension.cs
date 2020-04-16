using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ImageProcessing.App.CommonLayer.Attributes;

namespace ImageProcessing.App.CommonLayer.Extensions.TypeExtensions
{
    /// <summary>
    /// Extension methods for a <see cref="Type"> class.
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Get all the methods, decorated by the <typeparamref name="TAttribute"/>
        /// </summary>
        public static IEnumerable<MethodInfo> GetMethodsByAttribute<TAttribute>(
            this Type type, BindingFlags flags)
            where TAttribute : Attribute
            => type.GetMethods(flags).Where(
                method => method.GetCustomAttribute(typeof(TAttribute), false) != null
            );

        /// <summary>
        /// Get all the methods,
        /// decorated by the <see cref="CommandAttribute"/>
        /// as key-value pairs.
        /// </summary>
        public static Dictionary<string, CommandAttribute> GetCommands(this Type type)
           => type
               .GetMethodsByAttribute<CommandAttribute>(
                   BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance)
               .ToDictionary(
                   method => method.GetCustomAttribute<CommandAttribute>().Key,
                   method =>
                   {
                       var attr = method.GetCustomAttribute<CommandAttribute>();
                       attr.Method = method;

                       return attr;
                   });

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
