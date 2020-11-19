using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    internal sealed class BilinearInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double xScale, double yScale)
        {
            if(yScale == 0 && xScale == 0) { return src; }

            var dstWidth = src.Size.Width + (int)(src.Size.Width * xScale);
            var dstHeight = src.Size.Height + (int)(src.Size.Height * yScale);

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
                .DrawFilledRectangle(Brushes.White);

            var srcData = src.LockBits(
                new Rectangle(0, 0, src.Width, src.Height),
                ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dst.Width, dst.Height),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var ptrStep = dst.GetBitsPerPixel() / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                var (srcWidth, srcHeight) = (src.Width, src.Height);
                var (xBound, yBound) = (srcWidth - 2, srcHeight - 2);

                var dy = srcHeight / (double)dstHeight;
                var dx = srcWidth / (double)dstWidth;

                var setStep = ptrStep;

                Parallel.For(0, dstHeight, options, y =>
                {
                    var newY = y * dy + 0.5;
                    var yFlr = (int)newY;
                    var yFrc = newY - yFlr;

                    if (yFlr > yBound) { yFlr = yBound; }

                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;

                    var i0 = srcStartPtr +  yFlr      * srcData.Stride;
                    var i1 = srcStartPtr + (yFlr + 1) * srcData.Stride;

                    double col0, col1, point;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {  
                        var newX = x * dx + 0.5;
                        var xFlr = (int)newX;
                        var xFrc = newX - xFlr;

                        if (xFlr > xBound) { xFlr = xBound; }

                        var j0 =  xFlr * ptrStep;
                        var j1 = (xFlr + 1) * ptrStep;

                        var p00 = i0 + j0; var p10 = i1 + j0;                      
                        var p01 = i0 + j1; var p11 = i1 + j1;

                        var xFrcCompl = 1 - xFrc;
                        var yFrcCompl = 1 - yFrc;

                        col0 = p00[0] * xFrcCompl + p10[0] * xFrc;
                        col1 = p01[0] * xFrcCompl + p11[0] * xFrc;

                        point = col0 * yFrcCompl + col1 * yFrc;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[0] = (byte)point;

                        col0 = p00[1] * xFrcCompl + p10[1] * xFrc;
                        col1 = p01[1] * xFrcCompl + p11[1] * xFrc;

                        point = col0 * yFrcCompl + col1 * yFrc;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[1] = (byte)point;

                        col0 = p00[2] * xFrcCompl + p10[2] * xFrc;
                        col1 = p01[2] * xFrcCompl + p11[2] * xFrc;

                        point = col0 * yFrcCompl + col1 * yFrc;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[2] = (byte)point;
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
    }
}
