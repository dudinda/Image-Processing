using System.Drawing;

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
