using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    public sealed class ScaleTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double sx, double sy)
        {
            if (src is null) { throw new ArgumentNullException(nameof(src)); }
            if (src.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            if (sx == 1d && sy == 1d) { return src; }

            var (dstWidth, dstHeight) = ((int)(src.Width * sx), (int)(src.Height * sy));

            if (dstWidth <= 0) { throw new ArgumentException(nameof(sx)); }
            if (dstHeight <= 0) { throw new ArgumentException(nameof(sy)); }

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
                .DrawFilledRectangle(Brushes.White);

            var srcData = src.LockBits(
                new Rectangle(0, 0, src.Width, src.Height),
                ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dst.Width, dst.Height),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var (srcWidth, srcHeight) = (src.Width, src.Height);
            var (dSrcWidth, dSrcHeight) = ((double)srcWidth, (double)srcHeight);
            var (srcStride, dstStride) = (srcData.Stride, dstData.Stride);

            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                //inv(A)v = v'
                // where A is a scale matrix
                Parallel.For(0, dstHeight, options, y =>
                {
                    var srcY = y / sy;

                    if (srcY < dSrcHeight && srcY >= 0d)
                    {
                        //get the address of a row
                        var dstRow = dstStartPtr +         y * dstStride;
                        var srcRow = srcStartPtr + (int)srcY * srcStride;

                        double srcX;

                        byte* srcPtr;

                        for (var x = 0; x < dstWidth; ++x, dstRow += step)
                        {
                            srcX = x / sx;

                            if (srcX < dSrcWidth && srcX >= 0d)
                            {
                                srcPtr = srcRow + (int)srcX * step;

                                dstRow[0] = srcPtr[0];
                                dstRow[1] = srcPtr[1];
                                dstRow[2] = srcPtr[2];
                                dstRow[3] = srcPtr[3];
                            }
                        }
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
    }   
}
