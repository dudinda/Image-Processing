using ImageProcessing.Common.Enums;

using System;

namespace ImageProcessing.Common.Attributes
{
    /// <summary>
    /// Attribute is used to decorate classes, implementing IColor interface
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ColorAttribute : Attribute
    {
        /// <summary>
        /// a color combination of R, G or B
        /// </summary>
        public RGBColors Color { get; }

        public ColorAttribute(RGBColors color)
        {
            Color = color;
        }
    }
}
