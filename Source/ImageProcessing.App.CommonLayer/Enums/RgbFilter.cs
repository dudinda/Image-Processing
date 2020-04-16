using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// Specifies filters based on the RGB color space.
    /// </summary>
    public enum RgbFilter
    {
        /// <summary>
        /// An unknown filter.
        /// </summary>
        [Description("Filter is not specified")]
        Unknown = 0,

        /// <summary>
        /// Grayscale filter.
        /// </summary>
        [Description("Grayscale filter")]
        Grayscale = 1,

        /// <summary>
        /// Filter by a color channel.
        /// </summary>
        [Description("RGB Filter")]
        Color     = 2,

        /// <summary>
        /// Inversion filter.
        /// </summary>
        [Description("Inversion filter")]
        Inversion = 3,

        /// <summary>
        /// Binary filter.
        /// </summary>
        [Description("Binary filter")]
        Binary    = 4
    }
}
