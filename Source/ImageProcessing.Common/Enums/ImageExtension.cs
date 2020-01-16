using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// The enum, representing an extension of an image .
    /// </summary>
    public enum ImageExtension
    {
        /// <summary>
        /// An unknown image extension
        /// </summary>
        Unknown =  0,

        /// <summary>
        /// .Jpeg
        /// </summary>
        [Description(".jpeg")]
        Jpeg      = 1,

        /// <summary>
        /// .Bmp
        /// </summary>
        [Description(".bmp")]
        Bmp       = 2,

        /// <summary>
        /// .Emf
        /// </summary>
        [Description(".emf")]
        Emf       = 3,

        /// <summary>
        /// .Exif
        /// </summary>
        [Description(".exif")]
        Exif      = 4,

        /// <summary>
        /// .Gif
        /// </summary>
        [Description(".gif")]
        Gif       = 5,

        /// <summary>
        /// .Icon
        /// </summary>
        [Description(".icon")]
        Icon      = 6,

        /// <summary>
        /// .MemoryBmp
        /// </summary>
        [Description(".memorybmp")]
        MemoryBmp = 7,

        /// <summary>
        /// .Tiff
        /// </summary>
        [Description(".tiff")]
        Tiff      = 8
    }
}
