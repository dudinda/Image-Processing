using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using ImageProcessing.App.Domain.Code.Extensions;
using ImageProcessing.App.Domain.Win.Code.Enums;
namespace ImageProcessing.App.Domain.Win.Code.Extensions
{
    /// <summary>
    /// Extension methods for a <see cref="Bitmap"> class.
    /// </summary>
    public static class BitmapExtension
    {
        extension(string ext)
        {
            /// <summary>
            /// Get a <see cref="Bitmap"/> extension.
            /// </summary>
            /// <param name="ext"></param>
            /// <returns></returns>
            public ImageFormat GetImageFormat()
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
        }

        extension(Image image)
        {
            /// <summary>
            /// Save an image to the specified path.
            /// </summary>
            public void SaveByPath(string path)
                => image.Save(path, Path.GetExtension(path).GetImageFormat());
        }
    }
}
