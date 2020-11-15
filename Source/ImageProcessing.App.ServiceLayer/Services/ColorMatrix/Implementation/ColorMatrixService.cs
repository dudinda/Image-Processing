using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Implementation
{
    /// <inheritdoc cref="IColorMatrixService"/>
    internal sealed class ColorMatrixService : IColorMatrixService
    {
        /// <inheritdoc/>
        public Bitmap Apply(Bitmap source, ReadOnly2DArray<double> mtx)
        {
            var bitmapData = source.LockBits(
              new Rectangle(0, 0, source.Width, source.Height),
              ImageLockMode.ReadWrite, source.PixelFormat);

            var size = source.Size;
            var ptrStep = source.GetBitsPerPixel() / 8;

            if(ptrStep != 4)
            {
                throw new InvalidOperationException($"{source.PixelFormat} is not supported.");
            }

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var (a00, a01, a02, a03, a04) = (mtx[0, 0], mtx[0, 1], mtx[0, 2], mtx[0, 3], mtx[0, 4] * 255);
                var (a10, a11, a12, a13, a14) = (mtx[1, 0], mtx[1, 1], mtx[1, 2], mtx[1, 3], mtx[1, 4] * 255);
                var (a20, a21, a22, a23, a24) = (mtx[2, 0], mtx[2, 1], mtx[2, 2], mtx[2, 3], mtx[2, 4] * 255);
                var (a30, a31, a32, a33, a34) = (mtx[3, 0], mtx[3, 1], mtx[3, 2], mtx[3, 3], mtx[3, 4] * 255);

                //Ax = x'
                Parallel.For(0, size.Height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * bitmapData.Stride;

                    double r, g, b, a;

                    for (var x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        r = a00 * ptr[2] + a01 * ptr[1] + a02 * ptr[0] + a03 * ptr[3] + a04;
                        g = a10 * ptr[2] + a11 * ptr[1] + a12 * ptr[0] + a13 * ptr[3] + a14;
                        b = a20 * ptr[2] + a21 * ptr[1] + a22 * ptr[0] + a23 * ptr[3] + a24;
                        a = a30 * ptr[2] + a31 * ptr[1] + a32 * ptr[0] + a33 * ptr[3] + a34;

                        if (r > 255) { r = 255; } else if (r < 0) { r = 0; }
                        if (g > 255) { g = 255; } else if (g < 0) { g = 0; }
                        if (b > 255) { b = 255; } else if (b < 0) { b = 0; }
                        if (a > 255) { a = 255; } else if (a < 0) { a = 0; }

                        ptr[0] = (byte)b;  ptr[1] = (byte)g;  ptr[2] = (byte)r;  ptr[3] = (byte)a;
                    }
                });
            }

            source.UnlockBits(bitmapData);

            return source;
        }         
    }
}
