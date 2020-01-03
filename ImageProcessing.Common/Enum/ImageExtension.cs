using System.ComponentModel;

namespace ImageProcessing.Common.Enum
{
    public enum ImageExtension
    {
        [Description(".jpeg")]
        Jpeg      = 0,

        [Description(".bmp")]
        Bmp       = 1,

        [Description(".png")]
        Png       = 2,

        [Description(".emf")]
        Emf       = 3,

        [Description(".exif")]
        Exif      = 4,

        [Description(".gif")]
        Gif       = 5,

        [Description(".icon")]
        Icon      = 6,

        [Description(".memorybmp")]
        MemoryBmp = 7,

        [Description(".tiff")]
        Tiff      = 8
    }
}
