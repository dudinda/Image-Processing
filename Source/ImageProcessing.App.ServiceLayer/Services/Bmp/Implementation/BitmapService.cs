using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Bmp.Implementation
{
    /// <inheritdoc cref="IBitmapService"/>
    public sealed class BitmapService : IBitmapService
    {
        /// <inheritdoc/>
        public Bitmap Normalize(Bitmap bitmap)
        {
            bitmap.IsSupported();

            var max = Max(bitmap);
            var min = Min(bitmap);

            var newMax = 255;
            var newMin = 0;

            var divisor = (double)(newMax - newMin) / (double)(max - min);

            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var size = bitmap.Size;
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var stride = bitmapData.Stride;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var (dstWidth, dstHeight) = (size.Width, size.Height);

                Parallel.For(0, dstHeight, options, y =>
                {
                    var ptr = startPtr + y * stride;

                    for (int x = 0; x < dstWidth; ++x, ptr += step)
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
            bitmap.IsSupported();

            var result = new Bitmap(bitmap);
            var resultData = result.LockBits(
                new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var size = result.Size;
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var stride = resultData.Stride;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                //get a pointer to the start of an image
                var startPtr = (byte*)resultData.Scan0.ToPointer();

                var bag = new ConcurrentBag<byte>();

                var (dstWidth, dstHeight) = (size.Width, size.Height);

                //take N partial sums
                Parallel.For<byte>(0, dstHeight, options, () => 0, (y, state, max) =>
                {
                    var ptr = startPtr + y * stride;

                    for (var x = 0; x < dstWidth; ++x, ptr += step)
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
            bitmap.IsSupported();

            var result = new Bitmap(bitmap);
            var resultData = result.LockBits(
                new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var size = result.Size;
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var stride = resultData.Stride;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)resultData.Scan0.ToPointer();

                var bag = new ConcurrentBag<byte>();

                var (dstWidth, dstHeight) = (size.Width, size.Height);

                Parallel.For<byte>(0, dstHeight, options, () => 255, (y, state, min) =>
                {
                    var ptr = startPtr + y * stride;

                    for (var x = 0; x < dstWidth; ++x, ptr += step)
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
        public  Bitmap Shuffle(Bitmap bitmap)
        {
            bitmap.IsSupported();

            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var resolution = bitmap.Width * bitmap.Height;
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;

            var random = new Random(Guid.NewGuid().GetHashCode());

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                byte r, g, b;

                var ptr = startPtr;

                for (var index = resolution - 1; index > 1; --index, ptr += step)
                {
                    var newPtr = startPtr + random.Next(index) * step;

                    r = ptr[0];
                    g = ptr[1];
                    b = ptr[2];
                   
                    ptr[0] = newPtr[0];
                    ptr[1] = newPtr[1];
                    ptr[2] = newPtr[2];

                    newPtr[0] = r;
                    newPtr[1] = g;
                    newPtr[2] = b;

                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        /// <inheritdoc/>
        public Bitmap Magnitude(Bitmap xDerivative, Bitmap yDerivative)
        {
            xDerivative.IsSupported(); yDerivative.IsSupported();

            var result = new Bitmap(xDerivative);

            var xDerivativeData = xDerivative.LockBits(
                new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.ReadOnly, xDerivative.PixelFormat);

            var yDerivativeData = yDerivative.LockBits(
                new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.ReadOnly, yDerivative.PixelFormat);

            var resultData = result.LockBits(
                new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.WriteOnly, result.PixelFormat);

            var size = result.Size;
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;

            var (yStride, xStride) = (yDerivativeData.Stride, xDerivativeData.Stride);
            var stride = resultData.Stride;

            unsafe
            {
                var xDerivativeStartPtr = (byte*)xDerivativeData.Scan0.ToPointer();
                var yDerivativeStartPtr = (byte*)yDerivativeData.Scan0.ToPointer();
                var resultStartPtr      = (byte*)resultData.Scan0.ToPointer();

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                var (dstWidth, dstHeight) = (size.Width, size.Height);

                Parallel.For(0, dstHeight, options, y =>
                {
                    var resultPtr      = resultStartPtr      + y * stride;
                    var xDerivativePtr = xDerivativeStartPtr + y * xStride;
                    var yDerivativePtr = yDerivativeStartPtr + y * yStride;

                    for (var x = 0; x < dstWidth; ++x, resultPtr += step, xDerivativePtr += step, yDerivativePtr += step)
                    {
                        double Gx = xDerivativePtr[0];
                        double Gy = yDerivativePtr[0];

                        var magnitude = Math.Sqrt(Gx * Gx + Gy * Gy);

                        if (magnitude > 255d)
                        {
                            magnitude = 255d;
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
