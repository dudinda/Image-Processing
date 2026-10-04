using System.Drawing;

namespace ImageProcessing.App.Domain.Code.Extensions
{
    /// <summary>
    /// Extension methods for a <see cref="Bitmap"> class.
    /// </summary>
    public static class BitmapExtension
    {
        extension(Bitmap bmp)
        {
            public Bitmap DrawFilledRectangle(Brush brush)
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
            public  Bitmap AdjustBorder(int numberOfPixels, Color borderColor)
            {
                var result = new Bitmap(bmp);

                using (var g = Graphics.FromImage(result))
                {
                    g.DrawRectangle(new Pen(borderColor, numberOfPixels), new Rectangle(0, 0, bmp.Width, bmp.Height));
                }

                return result;
            }
        }
    }
}
