using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Extensions.EnumExtensions
{
    public static class EnumExtension
    {
        public static T GetEnumValueByName<T>(this string value) {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
