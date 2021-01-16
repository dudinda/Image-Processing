using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions.EnumExt;

namespace ImageProcessing.App.ServiceLayer.Win.Code.Extensions.BitmapExt
{
    /// <summary>
    /// Extension methods for a <see cref="Bitmap"> class.
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Get a <see cref="Bitmap"/> extension.
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static ImageFormat GetImageFormat(this string ext)
            => ext.GetValueFromDescription<ImageExtension>()
        switch
        {
            ImageExtension.Jpeg
                => ImageFormat.Jpeg,
            ImageExtension.Bmp
                => ImageFormat.Bmp,
            ImageExtension.Png
                => ImageFormat.Png,
            ImageExtension.Emf
                => ImageFormat.Emf,
            ImageExtension.Exif
                => ImageFormat.Exif,
            ImageExtension.Gif
                => ImageFormat.Gif,
            ImageExtension.Icon
                => ImageFormat.Icon,
            ImageExtension.MemoryBmp
                => ImageFormat.MemoryBmp,
            ImageExtension.Tiff
                => ImageFormat.Tiff,
            ImageExtension.Wmf
                => ImageFormat.Wmf,
            ImageExtension.Jpg
                => ImageFormat.Jpeg,

            _ => throw new NotImplementedException(ext)
        };

        /// <summary>
        /// Save an image to the specified path.
        /// </summary>
        public static void SaveByPath(this Image image, string path)
            => image.Save(path, Path.GetExtension(path).GetImageFormat());      
    }
}
