using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Extensions.BitmapExtensions;
using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Binary
{
    /// <summary>
    /// Implements the <see cref="IRgbFilter"/>.
    /// </summary>
    internal sealed class BinaryFilter : IRgbFilter
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                             ImageLockMode.ReadWrite,
                                             bitmap.PixelFormat);
            var rec = Luma.Rec709;
            
            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            var size = bitmap.Size;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var bag = new ConcurrentBag<double>();

                //get N luminance partial sums
                Parallel.For(0, size.Height, options, () => 0.0, (y, state, partial) =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        partial += Recommendation
                        .GetLumaCoefficients(
                            ref ptr[2], ref ptr[1], ref ptr[0], ref rec
                        );
                    }

                    return partial;
                },
                (x) => bag.Add(x));

                //get luminance average
                var average = bag.Sum() / (size.Width * size.Height);

                Parallel.For(0, size.Height, options, y =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    var luminance = 0.0;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        luminance = Recommendation
                        .GetLumaCoefficients(
                            ref ptr[2], ref ptr[1], ref ptr[0], ref rec
                        );

                        //if relative luminance greater or equal than average
                        //set it to white
                        if (luminance >= average)
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
