using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// Specified an image container of the main window.
    /// </summary>
    public enum ImageContainer
    {
        /// <summary>
        /// An unknown container.
        /// </summary>
        Unknown     = 0,

        /// <summary>
        /// The left-hand image in the container.
        /// </summary>
        Source      = 1,
        
        /// <summary>
        /// The right-hand image in the container.
        /// </summary>
        Destination = 2,
    }
}
