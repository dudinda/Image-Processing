using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Bmp.Implementation
{
    /// <inheritdoc cref="IBitmapService"/>
    internal sealed class BitmapService : IBitmapService
    {
        /// <inheritdoc/>
        public Bitmap Normalize(Bitmap bitmap)
        {
            var max = Max(bitmap);
            var min = Min(bitmap);

            var newMax = 255;
            var newMin = 0;

            var divisor = (double)(newMax - newMin) / (double)(max - min);

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
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        ptr[0] = (byte)(((ptr[0] - min) * divisor) + newMin);
                        ptr[1] = (byte)(((ptr[1] - min) * divisor) + newMin);
                        ptr[2] = (byte)(((ptr[2] - min) * divisor) + newMin);
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        /// <inheritdoc/>
        public byte Max(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap);
            var resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                           ImageLockMode.ReadOnly,
                                                           bitmap.PixelFormat);

            var size = result.Size;
            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            unsafe
            {
                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;

                //get a pointer to the start of an image
                var startPtr = (byte*)resultData.Scan0.ToPointer();

                var bag = new ConcurrentBag<byte>();

                //take N partial sums
                Parallel.For<byte>(0, size.Height, options, () => 0, (y, state, max) =>
                {
                    var ptr = startPtr + y * resultData.Stride;

                    for (var x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        if (max < ptr[0])
                        {
                            max = ptr[0];
                        }
                    }

                    return max;
                },
                (x) => bag.Add(x));

                return bag.Max();
            }
        }

        /// <inheritdoc/>
        public byte Min(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap);
            var resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                           ImageLockMode.ReadOnly,
                                                           bitmap.PixelFormat);

            var size = result.Size;
            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            unsafe
            {
                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                var startPtr = (byte*)resultData.Scan0.ToPointer();

                var bag = new ConcurrentBag<byte>();

                Parallel.For<byte>(0, size.Height, options, () => 255, (y, state, min) =>
                {
                    var ptr = startPtr + y * resultData.Stride;

                    for (var x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        if (min > ptr[0])
                        {
                            min = ptr[0];
                        }
                    }

                    return min;
                },
                (x) => bag.Add(x));

                return bag.Min();
            }
        }

        /// <inheritdoc/>
        public Bitmap Magnitude(Bitmap xDerivative, Bitmap yDerivative)
        {
            var result = new Bitmap(xDerivative);

            var xDerivativeData = xDerivative.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                       ImageLockMode.ReadOnly,
                                                       xDerivative.PixelFormat);

            var yDerivativeData = yDerivative.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                       ImageLockMode.ReadOnly,
                                                       yDerivative.PixelFormat);

            var resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                           ImageLockMode.WriteOnly,
                                                           result.PixelFormat);

            var size = result.Size;
            var ptrStep = result.GetBitsPerPixel() / 8;

            unsafe
            {
                var xDerivativeStartPtr = (byte*)xDerivativeData.Scan0.ToPointer();
                var yDerivativeStartPtr = (byte*)yDerivativeData.Scan0.ToPointer();
                var resultStartPtr      = (byte*)resultData.Scan0.ToPointer();

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                Parallel.For(0, size.Height, options, y =>
                {
                    var resultPtr      = resultStartPtr      + y * resultData.Stride;
                    var xDerivativePtr = xDerivativeStartPtr + y * xDerivativeData.Stride;
                    var yDerivativePtr = yDerivativeStartPtr + y * yDerivativeData.Stride;

                    for (var x = 0; x < size.Width; ++x, resultPtr += ptrStep, xDerivativePtr += ptrStep, yDerivativePtr += ptrStep)
                    {
                        double Gx = xDerivativePtr[0];
                        double Gy = yDerivativePtr[0];

                        var magnitude = Math.Sqrt(Gx * Gx + Gy * Gy);

                        if (magnitude > 255)
                        {
                            magnitude = 255;
                        }

                        resultPtr[0] = resultPtr[1] = resultPtr[2] = (byte)magnitude;
                    }
                });

                result.UnlockBits(resultData);
                xDerivative.UnlockBits(xDerivativeData);
                yDerivative.UnlockBits(yDerivativeData);

                return result;
            }

        }
    }
}
