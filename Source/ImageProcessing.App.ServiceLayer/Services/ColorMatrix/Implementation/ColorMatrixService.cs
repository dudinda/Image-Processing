using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.ServiceLayer.Code.Constants;
using ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Implementation
{
    /// <inheritdoc cref="IColorMatrixService"/>
    public sealed class ColorMatrixService : IColorMatrixService
    {
        /// <inheritdoc/>
        public Bitmap Apply(Bitmap src, ReadOnly2DArray<double> mtx)
        {
            if (src is null) { throw new ArgumentNullException(nameof(src)); }
            if (mtx is null) { throw new ArgumentNullException(nameof(mtx)); }
            if (src.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            var bitmapData = src.LockBits(
              new Rectangle(0, 0, src.Width, src.Height),
              ImageLockMode.ReadWrite, src.PixelFormat);

            var (width, height) = (src.Width, src.Height);
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();
                var stride = bitmapData.Stride;

                var (a00, a01, a02, a03, a04) = (mtx[0, 0], mtx[0, 1], mtx[0, 2], mtx[0, 3], mtx[0, 4] * 255d);
                var (a10, a11, a12, a13, a14) = (mtx[1, 0], mtx[1, 1], mtx[1, 2], mtx[1, 3], mtx[1, 4] * 255d);
                var (a20, a21, a22, a23, a24) = (mtx[2, 0], mtx[2, 1], mtx[2, 2], mtx[2, 3], mtx[2, 4] * 255d);
                var (a30, a31, a32, a33, a34) = (mtx[3, 0], mtx[3, 1], mtx[3, 2], mtx[3, 3], mtx[3, 4] * 255d);

                //Ax = x'
                Parallel.For(0, height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * stride;

                    double r, g, b, a;

                    for (var x = 0; x < width; ++x, ptr += step)
                    {
                        r = a00 * ptr[2] + a01 * ptr[1] + a02 * ptr[0] + a03 * ptr[3] + a04;
                        g = a10 * ptr[2] + a11 * ptr[1] + a12 * ptr[0] + a13 * ptr[3] + a14;
                        b = a20 * ptr[2] + a21 * ptr[1] + a22 * ptr[0] + a23 * ptr[3] + a24;
                        a = a30 * ptr[2] + a31 * ptr[1] + a32 * ptr[0] + a33 * ptr[3] + a34;

                        if (r > 255d) { r = 255d; } else if (r < 0d) { r = 0d; }
                        if (g > 255d) { g = 255d; } else if (g < 0d) { g = 0d; }
                        if (b > 255d) { b = 255d; } else if (b < 0d) { b = 0d; }
                        if (a > 255d) { a = 255d; } else if (a < 0d) { a = 0d; }

                        ptr[0] = (byte)b;  ptr[1] = (byte)g;  ptr[2] = (byte)r;  ptr[3] = (byte)a;
                    }
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }         
    }
}
