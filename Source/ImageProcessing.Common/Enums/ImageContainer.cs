using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Specified an image container of the main window.
    /// </summary>
    public enum ImageContainer
    {
        /// <summary>
        /// An unknown container.
        /// </summary>
        [Description("Image container is not specified")]
        Unknown     = 0,

        /// <summary>
        /// The left-hand image in the container.
        /// </summary>
        [Description("Source image container")]
        Source      = 1,
        
        /// <summary>
        /// The right-hand image in the container.
        /// </summary>
        [Description("Destination image container")]
        Destination = 2,
    }
}
