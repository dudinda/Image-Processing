using System;
using System.Reflection;

namespace ImageProcessing.Microkernel.DI.Code.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CommandAttribute : Attribute
    {
        public CommandAttribute(string key)
        {
            Key = key;
        }

        public string Key { get; }
        public MethodInfo Method { get; set; }
    }
}
