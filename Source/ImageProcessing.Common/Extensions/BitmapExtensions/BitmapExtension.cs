using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessing.Common.Extensions.BitmapExtensions
{
    /// <summary>
    /// Extension methods for <see cref="Bitmap"> class
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Perform the Fisher–Yates shuffle on a selected bitmap
        /// </summary>
        /// <param name="bitmap">A bitmap</param>
        /// <returns>The shuffled bitmap</returns>
        public static Bitmap Shuffle(this Bitmap bitmap)
        {
            if(bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            var resolution = bitmap.Width * bitmap.Height;

            var random = new Random();

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                byte R, G, B;

                var ptr = startPtr;

                for (var index = resolution - 1; index > 1; --index, ptr += 3)
                {
                    var newPtr = startPtr + random.Next(index) * 3;

                    B = ptr[0];
                    G = ptr[1];
                    R = ptr[2];

                    ptr[0] = newPtr[0];
                    ptr[1] = newPtr[1];
                    ptr[2] = newPtr[2];

                    newPtr[0] = B;
                    newPtr[1] = G;
                    newPtr[2] = R;

                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }


        public static Bitmap Normalize(Bitmap src)
        {
            if(src is null)
            {
                throw new ArgumentNullException(nameof(src));
            }

            var max = Max(src);
            var min = Min(src);
            var newMax = 255;
            var newMin = 0;

            var divisor = (double)(newMax - newMin) / (double)(max - min);

            var bitmapData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height),
                                                       ImageLockMode.ReadWrite,
                                                       PixelFormat.Format24bppRgb);

            var size = src.Size;

            var options = new ParallelOptions() {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        ptr[0] = (byte)(((ptr[0] - min) * divisor) + newMin);
                        ptr[1] = (byte)(((ptr[1] - min) * divisor) + newMin);
                        ptr[2] = (byte)(((ptr[2] - min) * divisor) + newMin);
                    }
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }
    
        private static int Max(Bitmap src)
        {
            var result = new Bitmap(src);
            var resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                           ImageLockMode.WriteOnly,
                                                           PixelFormat.Format24bppRgb);

            var size = result.Size;
            var maxima = 0;

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

                    for (var x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        if (max < ptr[0])
                        {
                            max = ptr[0];
                        }
                    }

                    return max;
                },
                (x) => bag.Add(x));

                maxima = bag.Max();
            }

            return maxima;
        }

        private static int Min(Bitmap src)
        {
            var result = new Bitmap(src);
            var resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                           ImageLockMode.WriteOnly,
                                                           PixelFormat.Format24bppRgb);

            var size = result.Size;
            var minima = 0;

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

                    for (var x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        if (min > ptr[0])
                        {
                            min = ptr[0];
                        }
                    }

                    return min;
                },
                (x) => bag.Add(x));

                minima = bag.Min();
            }

            return minima;
        }

        /// <summary>
        /// The gradient magnitude of an image
        /// </summary>
        /// <param name="xDerivative">An image processed by vertical sobel operator</param>
        /// <param name="yDerivative">An image processed by horizontal sobel operator</param>
        /// <returns>An image processed by the Sobel operator</returns>
        public static Bitmap Magnitude(Bitmap xDerivative, Bitmap yDerivative)
        {

            if(xDerivative is null)
            {
                throw new ArgumentNullException(nameof(xDerivative));
            }

            if (yDerivative is null)
            {
                throw new ArgumentNullException(nameof(yDerivative));
            }

            var result = new Bitmap(xDerivative.Width, xDerivative.Height);

            var xDerivativeData = xDerivative.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                       ImageLockMode.ReadOnly,
                                                       PixelFormat.Format24bppRgb);

            var yDerivativeData = yDerivative.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                       ImageLockMode.ReadOnly,
                                                       PixelFormat.Format24bppRgb);

            var resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                           ImageLockMode.WriteOnly,
                                                           PixelFormat.Format24bppRgb);

            var size = result.Size;

            unsafe
            {
                var xDerivativeStartPtr = (byte*)xDerivativeData.Scan0.ToPointer();
                var yDerivativeStartPtr = (byte*)yDerivativeData.Scan0.ToPointer();
                var resultStartPtr = (byte*)resultData.Scan0.ToPointer();

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                Parallel.For(0, size.Height, options, y =>
                {
                    var resultPtr = resultStartPtr + y * resultData.Stride;
                    var xDerivativePtr = xDerivativeStartPtr + y * xDerivativeData.Stride;
                    var yDerivativePtr = yDerivativeStartPtr + y * yDerivativeData.Stride;

                    for (int x = 0; x < size.Width; ++x, resultPtr += 3, xDerivativePtr += 3, yDerivativePtr += 3)
                    {
                        double Gx = xDerivativePtr[0];
                        double Gy = yDerivativePtr[0];

                        var magnitude = Math.Abs(Gx) + Math.Abs(Gy);

                        if (magnitude > 255) magnitude = 255;

                        resultPtr[0] = resultPtr[1] = resultPtr[2] = (byte)magnitude;
                    }
                });

                result.UnlockBits(resultData);
                xDerivative.UnlockBits(xDerivativeData);
                yDerivative.UnlockBits(yDerivativeData);

                return result;
            }

        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(this Image image, Size size)
        {
            var destRect = new Rectangle(0, 0, size.Width, size.Height);
            var destImage = new Bitmap(size.Width, size.Height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

    }
}
