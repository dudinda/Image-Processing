using System;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Bit field representing each channel of RGB space
    /// </summary>
    [Flags]
    public enum RGBColors
    {
        /// <summary>
        /// Channel isn't selected
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Red channel
        /// </summary>
        Red   = 1 << 0,

        /// <summary>
        ///Green channel 
        /// </summary>
        Green = 1 << 1,

        /// <summary>
        /// Blue channel
        /// </summary>
        Blue  = 1 << 2
    }
}
