using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    /// <summary>
    /// Implements the <see cref="IRgbFilter"/>.
    /// </summary>
    internal sealed class BinaryFilter : IRgbFilter
    {
        private readonly IRecommendation _rec;

        public BinaryFilter(IRecommendation rec)
        {
            _rec = rec;
        }

        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap)
        {
            bitmap.IsSupported();

            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var (width, height) = (bitmap.Width, bitmap.Height);
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            var step = sizeof(int);
            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();
                var stride = bitmapData.Stride;

                var bag = new ConcurrentBag<double>();

                //get N luminance partial sums
                Parallel.For(0, height, options, () => 0.0, (y, state, partial) =>
                {
                    var ptr = startPtr + y * stride;

                    for (var x = 0; x < width; ++x, ptr += step)
                    {
                        partial += _rec.GetLuma(
                            ref ptr[2], ref ptr[1], ref ptr[0]
                        );
                    }

                    return partial;
                },
                (x) => bag.Add(x));

                //get luminance average
                var average = bag.Sum() / (width * height);

                Parallel.For(0, height, options, y =>
                {
                    var ptr = startPtr + y * stride;

                    for (var x = 0; x < width; ++x, ptr += step)
                    {
                        //if relative luminance greater or equal than average
                        //set it to white
                        if (_rec.GetLuma(ref ptr[2], ref ptr[1], ref ptr[0]) >= average)
                        {
                            ptr[0] = ptr[1] = ptr[2] = 255;
                        }
                        //else to black
                        else
                        {
                            ptr[0] = ptr[1] = ptr[2] = 0;
                        }
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
