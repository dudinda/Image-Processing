using System;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Common.Attributes
{
    /// <summary>
    /// The attribute is used to decorate classes, implementing the IColor interface.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ColorAttribute : Attribute
    {
        /// <summary>
        /// A color combination of R, G and B.
        /// </summary>
        public RGBColors Color { get; }

        public ColorAttribute(RGBColors color)
        {
            Color = color;
        }
    }
}
