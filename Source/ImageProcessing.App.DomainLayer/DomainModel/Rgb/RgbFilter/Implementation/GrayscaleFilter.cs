using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    /// <summary>
    /// Implements the <see cref="IRgbFilter"/>.
    /// </summary>
    internal sealed class GrayscaleFilter : IRgbFilter
    {
        private readonly IRecommendation _rec;

        public GrayscaleFilter(IRecommendation rec)
        {
            _rec = rec;
        }

        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            var (width, height) = (bitmap.Width, bitmap.Height);
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < width; ++x, ptr += ptrStep)
                    {
                        ptr[0] = ptr[1] = ptr[2] = (byte)_rec.GetLuma(
                            ref ptr[2], ref ptr[1], ref ptr[0]);
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
