using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// Specifies filters based on the RGB color space.
    /// </summary>
    public enum RgbFltr
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
        Binary    = 3,

        /// <summary>
        /// Flopping filter.
        /// </summary>
        [Description("Flop the image")]
        Flopping  = 4,

        /// <summary>
        /// Flipping filter.
        /// </summary>
        [Description("Flip the image")]
        Flipping  = 5
    }
}
