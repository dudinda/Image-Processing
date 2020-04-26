using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Recommendation.Implementation;
using ImageProcessing.App.DomainLayer.Model.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Interface;

namespace ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Grayscale
{
    /// <summary>
    /// Implements the <see cref="IRgbFilter"/>.
    /// </summary>
    internal sealed class GrayscaleFilter : IRgbFilter
    {
        private static IRecommendation _rec
            = new RecommendationFactory().Get(Luma.Rec709);

        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                             ImageLockMode.ReadWrite,
                                             bitmap.PixelFormat);

            var size = bitmap.Size;
            var ptrStep = bitmap.GetBitsPerPixel() / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        ptr[0] = ptr[1] = ptr[2] = (byte)_rec.GetLuma(
                            ref ptr[2], ref ptr[1], ref ptr[0]
                        );
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
