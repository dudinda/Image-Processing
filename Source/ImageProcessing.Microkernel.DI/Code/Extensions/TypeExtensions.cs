using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ImageProcessing.Microkernel.DI.Code.Attributes;

namespace ImageProcessing.Microkernel.DI.Code.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Get all the methods, decorated by the <typeparamref name="TAttribute"/>
        /// </summary>
        public static IEnumerable<MethodInfo> GetMethodsByAttribute<TAttribute>(
            this Type type, BindingFlags flags)
            where TAttribute : Attribute
            => type.GetMethods(flags)
                   .Where(method => method.GetCustomAttribute(typeof(TAttribute), false) != null);

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
    }
}
