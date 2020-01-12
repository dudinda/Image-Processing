using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.Distributions.Abstract;

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
                                             PixelFormat.Format32bppRgb);

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var size = bitmap.Size;

            unsafe
            {
                Parallel.For(0, size.Height, options, y =>
                {
                    //get a start address
                    var ptr = (byte*)bitmapData.Scan0.ToPointer() + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 4)
                    {
                        //get a new pixel value, transofrming by a quantile
                        ptr[0] = ptr[1] = ptr[2] = newPixels[ptr[0]];
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        private double[] GetPMFImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequenciesImpl(bitmap);

            return base.GetPMF(frequencies, Convert.ToUInt32(bitmap.Width * bitmap.Height));
        }

        private double[] GetCDFImpl(Bitmap bitmap)
        {
            return base.GetCDF(GetPMFImpl(bitmap));
        }

        private double GetExpectationImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequencies(bitmap);

            var pmf = base.GetPMFImpl(frequencies, Convert.ToUInt32(bitmap.Width * bitmap.Height));

            return base.GetExpectation(pmf);
        }

        private double GetVarianceImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequenciesImpl(bitmap);

            var pmf = base.GetPMF(frequencies, Convert.ToUInt32(bitmap.Width * bitmap.Height));

            return base.GetVariance(pmf);
        }

        private int[] GetFrequenciesImpl(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            ImageLockMode.ReadWrite,
                                            PixelFormat.Format24bppRgb);

            var frequencies = new int[256];

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

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
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

        private double GetEntropyImpl(Bitmap bmp)
        {
            var pmf = base.GetPMF(GetFrequencies(bmp), Convert.ToUInt32(bmp.Height * bmp.Width));

            return base.GetEntropy(pmf);

        }

        private double GetStandardDeviationImpl(Bitmap bitmap)
        {
            return Math.Sqrt(GetVarianceImpl(bitmap));
        }

        private double GetConditionalExpectationImpl((int x1, int x2) interval, Bitmap bitmap)
        {
            var pmf = GetPMFImpl(bitmap);

            return base.GetConditionalExpectation(interval, pmf);
        }

        private double GetConditionalVarianceImpl((int x1, int x2) interval, Bitmap bitmap)
        {
            var pmf = GetPMFImpl(bitmap);

            return base.GetConditionalVarianceImpl(interval, pmf);
        }

        private byte[] TransformImpl(double[] cdf, IDistribution distribution)
        {
            var result = new byte[256];

            //transform an array by a quantile function
            for (int index = 0; index < 256; ++index)
            {
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
