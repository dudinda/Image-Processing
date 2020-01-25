using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Extensions.DecimalMathExtensions;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Implementation
{
    public partial class BitmapLuminanceDistributionService
    {
        private Bitmap TransformToImpl(Bitmap bitmap, IDistribution distribution)
        {
            var cdf = GetCDFImpl(bitmap);

            //get new pixel values, according to a selected distribution
            var newPixels = TransformImpl(cdf, distribution);

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                             ImageLockMode.ReadWrite,
                                             bitmap.PixelFormat);

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            var ptrStep = bitmap.GetBitsPerPixel() / 8;
            var size = bitmap.Size;

            unsafe
            {
                Parallel.For(0, size.Height, options, y =>
                {
                    //get a start address
                    var ptr = (byte*)bitmapData.Scan0.ToPointer() + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        //get a new pixel value, transofrming by a quantile
                        ptr[0] = ptr[1] = ptr[2] = newPixels[ptr[0]];
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        private decimal[] GetPMFImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequenciesImpl(bitmap);

            return base.GetPMF(frequencies);
        }

        private decimal[] GetCDFImpl(Bitmap bitmap)
        {
            return base.GetCDF(GetPMFImpl(bitmap));
        }

        private decimal GetExpectationImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequencies(bitmap);

            var pmf = base.GetPMFImpl(frequencies);

            return base.GetExpectation(pmf);
        }

        private decimal GetVarianceImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequenciesImpl(bitmap);

            var pmf = base.GetPMF(frequencies);

            return base.GetVariance(pmf);
        }

        private int[] GetFrequenciesImpl(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            ImageLockMode.ReadWrite,
                                            bitmap.PixelFormat);

            var frequencies = new int[256];
            var ptrStep = bitmap.GetBitsPerPixel() / 8;
            unsafe
            {
                var size = bitmap.Size;

                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;

                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var bag = new ConcurrentBag<int[]>();

                //get N partial frequency arrays
                Parallel.For<int[]>(0, size.Height, options, () => new int[256], (y, state, subarray) =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        subarray[ptr[0]]++;
                    }

                    return subarray;
                },
                (part) => bag.Add(part));

                //get summary frequencies
                foreach (var subarray in bag)
                {
                    for (int i = 0; i < 256; ++i)
                    {
                        frequencies[i] += subarray[i];
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);

            return frequencies;
        }

        private decimal GetEntropyImpl(Bitmap bmp)
        {
            var pmf = base.GetPMF(GetFrequencies(bmp));

            return base.GetEntropy(pmf);

        }

        private decimal GetStandardDeviationImpl(Bitmap bitmap)
        {
            return GetVarianceImpl(bitmap).Sqrt();
        }

        private decimal GetConditionalExpectationImpl((int x1, int x2) interval, Bitmap bitmap)
        {
            var pmf = GetPMFImpl(bitmap);

            return base.GetConditionalExpectation(interval, pmf);
        }

        private decimal GetConditionalVarianceImpl((int x1, int x2) interval, Bitmap bitmap)
        {
            var pmf = GetPMFImpl(bitmap);

            return base.GetConditionalVarianceImpl(interval, pmf);
        }

        private byte[] TransformImpl(decimal[] cdf, IDistribution distribution)
        {
            var result = new byte[256];

            //transform an array by a quantile function
            for (int index = 0; index < 256; ++index)
            {
                cdf[index] = cdf[index] >= 1 ? cdf[index] - DecimalMath.Epsilon : cdf[index];

                var pixel = distribution.Quantile(cdf[index]);

                if (pixel > 255)
                {
                    pixel = 255;
                }

                if (pixel < 0)
                {
                    pixel = 0;
                }

                result[index] = Convert.ToByte(pixel);
            }

            return result;
        }
    }
}
