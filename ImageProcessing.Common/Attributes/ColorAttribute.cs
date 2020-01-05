using ImageProcessing.Common.Enums;

using System;

namespace ImageProcessing.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ColorAttribute : Attribute
    {
        public RGBColors Color { get; }

        public ColorAttribute(RGBColors color)
        {
            Color = color;
        }
    }
}
