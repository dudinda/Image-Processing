namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Filters based on RGB color space
    /// </summary>
    public enum RGBFilter
    {
        /// <summary>
        /// Grayscale filter
        /// </summary>
        Grayscale = 0,

        /// <summary>
        /// Filter by color channel
        /// </summary>
        Color     = 1,

        /// <summary>
        /// Inversion filter
        /// </summary>
        Inversion = 2,

        /// <summary>
        /// Binary filter
        /// </summary>
        Binary    = 3
    }
}
