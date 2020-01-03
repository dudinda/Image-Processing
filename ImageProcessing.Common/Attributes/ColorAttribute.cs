using ImageProcessing.Common.Enum;

using System;

namespace ImageProcessing.Common.Attributes
{
    [AttributeUsage(System.AttributeTargets.Class)]
    public class ColorAttribute : Attribute
    {
        public RGBColors Color { get; }

        public ColorAttribute(RGBColors color)
        {
            Color = color;
        }
    }
}
