using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Services.Distribution
{
    public partial class DistributionService
    {
        private Bitmap DistributeImpl(Bitmap bitmap, IDistribution distribution)
        {
            var frequencies = GetFrequenciesImpl(bitmap);
            var pmf = GetPMFImpl(frequencies, bitmap.Width * bitmap.Height);
            var cdf = GetCDFImpl(pmf);

            //get new pixel values, according to a selected distribution
            var newPixels = Transform(cdf, distribution);

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

        private double GetExpectationImpl(double[] pmf)
        {
            var total = 0.0;

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * i;
            }

            return total;
        }

        private double GetExpectationImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequencies(bitmap);
            var pmf         = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            return GetExpectation(pmf);
        }

        private double GetVarianceImpl(double[] pmf)
        {
            var total = 0.0;

            var mean = GetExpectationImpl(pmf);

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * (i - mean) * (i - mean);
            }

            return total;
        }

        private double GetVarianceImpl(Bitmap bitmap)
        {
            var frequencies = GetFrequencies(bitmap);
            var pmf         = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            return GetVarianceImpl(pmf);
        }

        private double GetStandardDeviationImpl(double[] pmf)
        {
            return Math.Sqrt(GetVarianceImpl(pmf));
        }

        private double GetStandardDeviationImpl(Bitmap bitmap)
        {
            return Math.Sqrt(GetVarianceImpl(bitmap));
        }

        private double GetConditionalExpectationImpl(int x1, int x2, double[] pmf)
        {
            var uvalue = 0.0;
            var lvalue = 0.0;

            for (var i = x1; i <= x2; ++i)
            {
                uvalue += (i * pmf[i]);
                lvalue += pmf[i];
            }

            return uvalue / lvalue;
        }

        private double GetConditionalVarianceImpl(int x1, int x2, double[] frequencies)
        {
            var mean = GetConditionalExpectationImpl(x1, x2, frequencies);

            var uvalue = 0.0;
            var lvalue = 0.0;

            for (var i = x1; i <= x2; ++i)
            {
                uvalue += frequencies[i] * ((i - mean) * (i - mean));
                lvalue += frequencies[i];
            }

            return uvalue / lvalue;
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

        private double[] GetCDFImpl(double[] pmf)
        {
            var cdf = pmf.Clone() as double[];

            for (int x = 1; x < cdf.Length; ++x)
            {
                cdf[x] += cdf[x - 1];
            }

            return cdf;
        }

        private double[] GetPMFImpl(int[] frequencies, double resolution)
        {
            return frequencies.AsParallel().Select(x => (double)x / resolution).ToArray();
        }

        private double GetEntropyImpl(Bitmap bmp)
        {
            var entropy = 0.0;

            var resolution = bmp.Height * bmp.Width;

            var pmf = GetPMF(GetFrequencies(bmp), resolution);

            for (var index = 0; index < 256; ++index)
            {
                if (pmf[index] > Double.Epsilon)
                {
                    entropy += (pmf[index] * Math.Log(pmf[index], 2));
                }
            }

            return -entropy;
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
