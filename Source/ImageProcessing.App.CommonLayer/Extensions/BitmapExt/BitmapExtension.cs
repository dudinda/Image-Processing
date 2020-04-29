using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;

namespace ImageProcessing.App.CommonLayer.Extensions.BitmapExt
{
    /// <summary>
    /// Extension methods for a <see cref="Bitmap"> class.
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Perform the Fisher–Yates shuffle on a selected bitmap.
        /// </summary>
        /// <param name="bitmap">A bitmap.</param>
        /// <returns>The shuffled bitmap.</returns>
        public static Bitmap Shuffle(this Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadWrite,
                                                        bitmap.PixelFormat);

            var resolution = bitmap.Width * bitmap.Height;
            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            var random = new Random(Guid.NewGuid().GetHashCode());

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                byte r, g, b;

                var ptr = startPtr;

                for (var index = resolution - 1; index > 1; --index, ptr += ptrStep)
                {
                    var newPtr = startPtr + random.Next(index) * ptrStep;

                    r = ptr[0];
                    g = ptr[1];
                    b = ptr[2];

                    ptr[0] = newPtr[0];
                    ptr[1] = newPtr[1];
                    ptr[2] = newPtr[2];

                    newPtr[0] = r;
                    newPtr[1] = g;
                    newPtr[2] = b;

                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        /// <summary>
        /// Resize an image to a specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(this Image image, Size size)
        {
            var destRect = new Rectangle(0, 0, size.Width, size.Height);
            var destImage = new Bitmap(size.Width, size.Height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Get a number of bits per pixel of a selected image.
        /// </summary>
        /// <param name="bitmap">A bitmap.</param>
        /// <returns>A number of bits per pixel.</returns>
        public static byte GetBitsPerPixel(this Bitmap bitmap)
        {
            switch (bitmap.PixelFormat)
            {
                case PixelFormat.Format8bppIndexed:
                    return 8;

                case PixelFormat.Format24bppRgb:
                    return 24;

                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    return 32;

                default: throw new NotSupportedException("Only 8, 24 and 32 bit images are supported.");
            }
        }

        /// <summary>
        /// Adjust an image border by the <paramref name="numberOfPixels"/>.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="numberOfPixels">Number of pixels to adjust.</param>
        /// <param name="borderColor">A color of the border.</param>
        /// <returns>An adjusted bitmap.</returns>
        public static Bitmap AdjustBorder(this Bitmap src, int numberOfPixels, Color borderColor)
        {
            var result = new Bitmap(src);

            using (var g = Graphics.FromImage(result))
            {
                g.DrawRectangle(new Pen(borderColor, numberOfPixels), new Rectangle(0, 0, src.Width, src.Height));
            }

            return result;
        }

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

            _ => throw new NotImplementedException(ext)
        };
    }
}
