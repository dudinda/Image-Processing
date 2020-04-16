using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExtensions;
using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainModel.Model.Distributions.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distributions.RandomVariable.Interface;
using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.Real;

namespace ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Implementation
{
    /// <see cref="IBitmapLuminanceDistributionService"/>
    public sealed class BitmapLuminanceDistributionService : IBitmapLuminanceDistributionService
    {
        private readonly IRandomVariableDistributionService _service;

        public BitmapLuminanceDistributionService(IRandomVariableDistributionService service)
        {
            _service = Requires.IsNotNull(
                service, nameof(service)
            );
        }

        /// <inheritdoc />
        public Bitmap Transform(Bitmap bitmap, IDistribution distribution)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(distribution, nameof(distribution));

            var cdf = GetCDF(bitmap);

            //get the new pixel values, according to a selected distribution
            var newPixels = _service.TransformToByte(cdf, distribution);

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
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    //get a start address
                    var ptr = startPtr + y * bitmapData.Stride;

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

        /// <inheritdoc />
        public decimal[] GetPMF(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return _service.GetPMF(
                GetFrequencies(bitmap)
            );
        }

        /// <inheritdoc />
        public decimal[] GetCDF(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return _service.GetCDF(
                GetPMF(bitmap)
            );
        }

        /// <inheritdoc />
        public decimal GetExpectation(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return _service.GetExpectation(
                _service.GetPMF(
                    GetFrequencies(bitmap)
                )
            );
        }

        /// <inheritdoc />
        public decimal GetVariance(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return _service.GetVariance(
                _service.GetPMF(
                    GetFrequencies(bitmap)
                )
            );
        }

        /// <inheritdoc />
        public int[] GetFrequencies(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            ImageLockMode.ReadWrite,
                                            bitmap.PixelFormat);

            var frequencies = new int[256];
            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            unsafe
            {
                var size = bitmap.Size;

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var bag = new ConcurrentBag<int[]>();

                //get N partial frequency arrays
                Parallel.For(0, size.Height, options, () => new int[256], (y, state, partial) =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        partial[ptr[0]]++;
                    }

                    return partial;
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

        /// <inheritdoc />
        public decimal GetEntropy(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return _service.GetEntropy(
                _service.GetPMF(
                    GetFrequencies(bitmap)
                )
            );
        }

        /// <inheritdoc />
        public decimal GetStandardDeviation(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetVariance(bitmap).Sqrt();
        }

        /// <inheritdoc />
        public decimal GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return _service.GetConditionalExpectation(interval,
                GetPMF(bitmap)
            );
        }

        /// <inheritdoc />
        public decimal GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return _service.GetConditionalVariance(interval,
                GetPMF(bitmap)
            );
        }   
    }
}
