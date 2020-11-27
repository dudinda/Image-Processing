using System;
using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// A bit field, representing each channel of the RGB color space.
    /// </summary>
    [Flags]
    public enum RgbChannels
    {
        /// <summary>
        /// The channel isn't selected.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The red channel.
        /// </summary>
        Red      = 1 << 0,

        /// <summary>
        ///The green channel. 
        /// </summary>
        Green    = 1 << 1,

        /// <summary>
        /// The blue channel.
        /// </summary>
        Blue     = 1 << 2
    }
}
