using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Enum, representing an extension of an image 
    /// </summary>
    public enum ImageExtension
    {
        /// <summary>
        /// .Jpeg
        /// </summary>
        [Description(".jpeg")]
        Jpeg      = 0,

        /// <summary>
        /// .Bmp
        /// </summary>
        [Description(".bmp")]
        Bmp       = 1,

        /// <summary>
        /// .Emf
        /// </summary>
        [Description(".emf")]
        Emf       = 2,

        /// <summary>
        /// .Exif
        /// </summary>
        [Description(".exif")]
        Exif      = 3,

        /// <summary>
        /// .Gif
        /// </summary>
        [Description(".gif")]
        Gif       = 4,

        /// <summary>
        /// .Icon
        /// </summary>
        [Description(".icon")]
        Icon      = 5,

        /// <summary>
        /// .MemoryBmp
        /// </summary>
        [Description(".memorybmp")]
        MemoryBmp = 6,

        /// <summary>
        /// .Tiff
        /// </summary>
        [Description(".tiff")]
        Tiff      = 7
    }
}
