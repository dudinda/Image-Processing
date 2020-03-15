using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessing.Common.Extensions.BitmapExtensions
{
    /// <summary>
    /// Extension methods for <see cref="Bitmap"> class
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Perform the Fisher–Yates shuffle on a selected bitmap.
        /// </summary>
        /// <param name="bitmap">A bitmap</param>
        /// <returns>The shuffled bitmap</returns>
        public static Bitmap Shuffle(this Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            var resolution = bitmap.Width * bitmap.Height;

            var random = new Random();

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                byte R, G, B;

                var ptr = startPtr;

                for (var index = resolution - 1; index > 1; --index, ptr += 3)
                {
                    var newPtr = startPtr + random.Next(index) * 3;

                    B = ptr[0];
                    G = ptr[1];
                    R = ptr[2];

                    ptr[0] = newPtr[0];
                    ptr[1] = newPtr[1];
                    ptr[2] = newPtr[2];

                    newPtr[0] = B;
                    newPtr[1] = G;
                    newPtr[2] = R;

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
        /// Get a number of bits per pixel of a selected image
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static byte GetBitsPerPixel(this Bitmap bmp)
        {
            switch (bmp.PixelFormat)
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

        public static Bitmap AdjustBorder(this Bitmap src, int numberOfPixels, Color borderColor)
        {
            var result = new Bitmap(src);

            using (var g = Graphics.FromImage(result))
            {
                g.DrawRectangle(new Pen(borderColor, numberOfPixels), new Rectangle(0, 0, src.Width, src.Height));
            }

            return result;
        }
    }
}
