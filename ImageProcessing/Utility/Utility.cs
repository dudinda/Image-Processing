using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessing.Utility
{
    public static class Utility
    {
        /// <summary>
        /// Получить формат изображения
        /// </summary>
        /// <param name="ext></param>
        /// <returns>
        /// Объект типа ImageFormat,
        /// соответствующий изображению
        /// </returns>
        public static ImageFormat GetImageFormat(this string ext)
        {
            if (ext.Equals(".jpeg")) return ImageFormat.Jpeg;
            if (ext.Equals(".bmp")) return ImageFormat.Bmp;
            if (ext.Equals(".png")) return ImageFormat.Png;
            if (ext.Equals(".emf")) return ImageFormat.Emf;
            if (ext.Equals(".exif")) return ImageFormat.Exif;
            if (ext.Equals(".gif")) return ImageFormat.Gif;
            if (ext.Equals(".icon")) return ImageFormat.Icon;
            if (ext.Equals(".memorybmp")) return ImageFormat.MemoryBmp;
            if (ext.Equals(".tiff")) return ImageFormat.Tiff;

            else return ImageFormat.Wmf;

        }

        public static Bitmap Normalize(Bitmap src)
        {
            var max = Max(src);
            var min = Min(src);
            var newMax = 255;
            var newMin = 0;

            var divisor = (double)(newMax - newMin) / (double)(max - min);

            var bitmapData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height),
                                                       ImageLockMode.ReadWrite,
                                                       PixelFormat.Format24bppRgb);

            var size = src.Size;

            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount;


            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    //получить адрес строки
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
                                                         System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                                         System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var size = result.Size;
            var maxima = 0;
            unsafe
            {

                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;

                //получить указатель на начало изображения
                var startPtr = (byte*)resultData.Scan0.ToPointer();

                var bag = new ConcurrentBag<byte>();

                //взять N частичных сумм
                Parallel.For<byte>(0, size.Height, options, () => 0, (y, state, max) =>
                {
                    var ptr = startPtr + y * resultData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
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
                                                         System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                                         System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var size = result.Size;
            var minima = 0;
            unsafe
            {

                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;

                //получить указатель на начало изображения
                var startPtr = (byte*)resultData.Scan0.ToPointer();

                var bag = new ConcurrentBag<byte>();

                //взять N частичных сумм
                Parallel.For<byte>(0, size.Height, options, () => 255, (y, state, min) =>
                {
                    var ptr = startPtr + y * resultData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
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

        public static Bitmap Magnitude(Bitmap xDerivative, Bitmap yDerivative)
        {
            var result = new Bitmap(xDerivative.Width, xDerivative.Height);

            var xDerivativeData = xDerivative.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var yDerivativeData = yDerivative.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                          System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                                          System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var size = result.Size;

            unsafe
            {
                var xDerivativeStartPtr = (byte*)xDerivativeData.Scan0.ToPointer();
                var yDerivativeStartPtr = (byte*)yDerivativeData.Scan0.ToPointer();
                var resultStartPtr      = (byte*)resultData.Scan0.ToPointer();
                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;


                Parallel.For(0, size.Height, options, y =>
                {
                    //получить адрес строки
                    var resultPtr      = resultStartPtr      + y * resultData.Stride;
                    var xDerivativePtr = xDerivativeStartPtr + y * xDerivativeData.Stride;
                    var yDerivativePtr = yDerivativeStartPtr + y * yDerivativeData.Stride;

                    for (int x = 0; x < size.Width; ++x, resultPtr += 3, xDerivativePtr += 3, yDerivativePtr += 3)
                    {
                        double Gx = xDerivativePtr[0];
                        double Gy = yDerivativePtr[0];

                        var magnitude =  Math.Abs(Gx) + Math.Abs(Gy);

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

        public static Bitmap Shuffle(this Bitmap bitmap)
        {
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

       

    }
}

