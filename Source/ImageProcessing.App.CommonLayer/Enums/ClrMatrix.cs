using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    public enum ClrMatrix
    {
        /// <summary>
        /// An unknown color matrix.
        /// </summary>
        [Description("Select a color matrix...")]
        Unknown  = 0,

        /// <summary>
        /// Grayscale by Rec. 709 color matrix.
        /// </summary>
        [Description("Grayscale by Rec. 709")]
        Grayscale709  = 1,

        /// <summary>
        /// Grayscale by Rec. 601 color matrix.
        /// </summary>
        [Description("Grayscale by Rec. 601")]
        Grayscale601  = 2,

        /// <summary>
        /// Grayscale by Smpte240M color matrix.
        /// </summary>
        [Description("Grayscale by Smpte 240M")]
        Grayscale240M = 3,

        /// <summary>
        /// Identity color matrix.
        /// </summary>
        [Description("Identity")]
        Identity      = 4,

        /// <summary>
        /// Sepia tone color matrix.
        /// </summary>
        [Description("Sepia tone")]
        SepiaTone     = 5,

        /// <summary>
        /// Inverse color matrix.
        /// </summary>
        [Description("Inverse")]
        Inverse       = 6,

        /// <summary>
        /// RGB to YIQ color matrix.
        /// </summary>
        [Description("RGB to YIQ")]
        RgbToYiq      = 7,

        /// <summary>
        /// YIQ to RGB color matrix
        /// </summary>
        [Description("YIQ to RGB")]
        YiqToRgb      = 8
    }
}
