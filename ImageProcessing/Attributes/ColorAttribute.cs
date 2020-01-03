using ImageProcessing.Enum;

using System;

namespace ImageProcessing.Attributes
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
