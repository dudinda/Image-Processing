using System.ComponentModel;

namespace ImageProcessing.App.SerivceLayer.Win.Code.Enums
{
    /// <summary>
    /// Specifies an extension of an image.
    /// </summary>
    public enum ImageExtension
    {
        /// <summary>
        /// An unknown image extension.
        /// </summary>
        [Description("Extension is not specified")]
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
        Tiff      = 8,

        /// <summary>
        /// .Wmf
        /// </summary>
        [Description(".wmf")]
        Wmf       = 9,

        /// <summary>
        /// .Png
        /// </summary>
        [Description(".png")]
        Png       = 10,

        /// <summary>
        /// .Jpg
        /// </summary>
        [Description(".jpg")]
        Jpg = 11
    }
}
