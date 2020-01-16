namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Filters based on the RGB color space.
    /// </summary>
    public enum RGBFilter
    {
        /// <summary>
        /// An unknown filter
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Grayscale filter.
        /// </summary>
        Grayscale = 1,

        /// <summary>
        /// Filter by a color channel.
        /// </summary>
        Color     = 2,

        /// <summary>
        /// Inversion filter.
        /// </summary>
        Inversion = 3,

        /// <summary>
        /// Binary filter.
        /// </summary>
        Binary    = 4
    }
}
