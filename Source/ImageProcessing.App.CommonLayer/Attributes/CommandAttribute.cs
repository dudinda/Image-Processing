using System;
using System.Reflection;

namespace ImageProcessing.App.CommonLayer.Attributes
{
    /// <summary>
    /// Execute a decorated method  by the key.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CommandAttribute : Attribute
    {
        public CommandAttribute(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        /// <summary>
        /// A key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// A method metadata.
        /// </summary>
        public MethodInfo Method { get; set; }
    }
}
