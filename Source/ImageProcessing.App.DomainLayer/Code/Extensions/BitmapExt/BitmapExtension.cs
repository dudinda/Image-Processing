using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt
{
    /// <summary>
    /// Extension methods for a <see cref="Bitmap"> class.
    /// </summary>
    public static class BitmapExtension
    {
        public static Bitmap DrawFilledRectangle(this Bitmap bmp, Brush brush)
        {
            using (var graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, bmp.Width, bmp.Height);
                graph.FillRectangle(brush, ImageSize);
            }

            return bmp;
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
                case PixelFormat.Format24bppRgb:
                    return 24;

                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    return 32;

                default: throw new NotSupportedException("Only 24 and 32 bit images are supported.");
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
    }
}
