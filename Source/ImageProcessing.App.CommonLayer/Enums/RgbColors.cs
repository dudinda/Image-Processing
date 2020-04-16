using System;
using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// A bit field, representing each channel of the RGB color space.
    /// </summary>
    [Flags]
    public enum RgbColors
    {
        /// <summary>
        /// The channel isn't selected.
        /// </summary>
        [Description("Color channel is not specified")]
        Unknown = 0,

        /// <summary>
        /// The red channel.
        /// </summary>
        [Description("Red color channel")]
        Red      = 1 << 0,

        /// <summary>
        ///The green channel. 
        /// </summary>
        [Description("Green color channel")]
        Green    = 1 << 1,

        /// <summary>
        /// The blue channel.
        /// </summary>
        [Description("Blue color channel")]
        Blue     = 1 << 2
    }
}
