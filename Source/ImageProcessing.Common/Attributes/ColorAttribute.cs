using System;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Common.Attributes
{
    /// <summary>
    /// The attribute is used to decorate classes, implementing the IColor interface.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ColorAttribute : Attribute
    {
        /// <summary>
        /// A color combination of R, G and B.
        /// </summary>
        public RgbColors Color { get; }

        public ColorAttribute(RgbColors color)
        {
            Color = color;
        }
    }
}
