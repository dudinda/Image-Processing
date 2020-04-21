using System;
using System.Reflection;

namespace ImageProcessing.App.CommonLayer.Attributes
{
    /// <summary>
    /// Execute by the key a decorated with the attribute method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CommandAttribute : Attribute
    {
        public CommandAttribute(string key)
        {
            if(key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            Key = key; 
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
