using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    public sealed class BilinearInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double xScale, double yScale)
        {
            if (src is null) { throw new ArgumentNullException(nameof(src)); }
            if (src.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            if (yScale == 0d && xScale == 0d) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var dstWidth = srcWidth + (int)(srcWidth * xScale);
            var dstHeight = srcHeight + (int)(srcHeight * yScale);

            if (dstWidth <= 0) { throw new ArgumentException(nameof(xScale)); }
            if (dstHeight <= 0) { throw new ArgumentException(nameof(yScale)); }

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
                .DrawFilledRectangle(Brushes.White);

            var srcData = src.LockBits(
                new Rectangle(0, 0, srcHeight, srcHeight),
                ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dstWidth, dstHeight),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                var (xBound, yBound) = (srcWidth - 2, srcHeight - 2);
                var (srcStride, dstStride) = (srcData.Stride, dstData.Stride);

                var dy = srcHeight / (double)dstHeight;
                var dx = srcWidth / (double)dstWidth;

                Parallel.For(0, dstHeight, options, y =>
                {
                    var newY = y * dy + 0.5;
                    var yFlr = (int)newY;
                    var yFrc = newY - yFlr;

                    if (yFlr > yBound) { yFlr = yBound; }

                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstStride;

                    var i0 = srcStartPtr + yFlr * srcStride;
                    //srcStartPtr + (yFlr + 1) * srcStride
                    var i1 = i0 + srcStride;

                    double col0, col1, point,
                           newX, xFrc, xFrcCompl, yFrcCompl;

                    int xFlr, j0, j1;

                    byte* p00, p01,
                          p10, p11;

                    for (var x = 0; x < dstWidth; ++x, dstRow += step)
                    {  
                        newX = x * dx + 0.5;
                        xFlr = (int)newX;
                        xFrc = newX - xFlr;

                        if (xFlr > xBound) { xFlr = xBound; }

                        j0 =  xFlr * step;
                        //(xFlr + 1) * ptrStep
                        j1 = j0 + step;

                        p00 = i0 + j0; p10 = i1 + j0;
                        p01 = i0 + j1; p11 = i1 + j1;

                        xFrcCompl = 1d - xFrc;
                        yFrcCompl = 1d - yFrc;

                        col0 = p00[0] * xFrcCompl + p10[0] * xFrc;
                        col1 = p01[0] * xFrcCompl + p11[0] * xFrc;

                        point = col0 * yFrcCompl + col1 * yFrc;

                        if (point > 255d) { point = 255d; } else if (point < 0d) { point = 0d; }

                        dstRow[0] = (byte)point;

                        col0 = p00[1] * xFrcCompl + p10[1] * xFrc;
                        col1 = p01[1] * xFrcCompl + p11[1] * xFrc;

                        point = col0 * yFrcCompl + col1 * yFrc;

                        if (point > 255d) { point = 255d; } else if (point < 0d) { point = 0d; }

                        dstRow[1] = (byte)point;

                        col0 = p00[2] * xFrcCompl + p10[2] * xFrc;
                        col1 = p01[2] * xFrcCompl + p11[2] * xFrc;

                        point = col0 * yFrcCompl + col1 * yFrc;

                        if (point > 255d) { point = 255d; } else if (point < 0d) { point = 0d; }

                        dstRow[2] = (byte)point;

                        col0 = p00[3] * xFrcCompl + p10[3] * xFrc;
                        col1 = p01[3] * xFrcCompl + p11[3] * xFrc;

                        point = col0 * yFrcCompl + col1 * yFrc;

                        if (point > 255d) { point = 255d; } else if (point < 0d) { point = 0d; }

                        dstRow[3] = (byte)point;
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
    }
}
