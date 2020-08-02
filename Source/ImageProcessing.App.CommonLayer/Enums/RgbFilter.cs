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
        [Description("Select a filter...")]
        Unknown = 0,

        /// <summary>
        /// Grayscale filter.
        /// </summary>
        [Description("Grayscale filter")]
        Grayscale = 1,

        /// <summary>
        /// Inversion filter.
        /// </summary>
        [Description("Inversion filter")]
        Inversion = 2,

        /// <summary>
        /// Binary filter.
        /// </summary>
        [Description("Binary filter")]
        Binary    = 3
    }
}
