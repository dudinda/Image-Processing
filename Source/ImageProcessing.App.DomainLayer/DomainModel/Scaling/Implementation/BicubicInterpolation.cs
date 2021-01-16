using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    internal sealed class BicubicInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double xScale, double yScale)
        {
            if(yScale == 0 && xScale == 0) { return src; }

            if (xScale == -1) { throw new ArgumentException(nameof(xScale)); }
            if (yScale == -1) { throw new ArgumentException(nameof(yScale)); } 

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var dstWidth = srcWidth + (int)(srcWidth * xScale);
            var dstHeight = srcHeight + (int)(srcHeight * yScale);

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
                .DrawFilledRectangle(Brushes.White);

            var srcData = src.LockBits(
                new Rectangle(0, 0, srcWidth, srcHeight),
                ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dstWidth, dstHeight),
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

                var (xBound, yBound) = (srcWidth - 3, srcHeight - 3);

                var dy = srcHeight / (double)dstHeight;
                var dx = srcWidth / (double)dstWidth;

                Parallel.For(0, dstHeight, options, y =>
                {
                    var newY = y * dy + 0.5;
                    var yFlr = (int)newY;
                    var yFrc = newY - yFlr;

                    if (yFlr <= 0) { yFlr = 1; } else if (yFlr > yBound) { yFlr = yBound; }

                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;

                    var i0 = srcStartPtr + (yFlr - 1) * srcData.Stride;
                    var i1 = srcStartPtr +  yFlr      * srcData.Stride;
                    var i2 = srcStartPtr + (yFlr + 1) * srcData.Stride;
                    var i3 = srcStartPtr + (yFlr + 2) * srcData.Stride;

                    double point;
                    double p0, p1, p2, p3;
                    double a, b, c, d;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        var newX = x * dx + 0.5;
                        var xFlr = (int)newX;
                        var xFrc = newX - xFlr;

                        if (xFlr <= 0) { xFlr = 1; } else if (xFlr > xBound ) { xFlr = xBound; }

                        var j0 = (xFlr - 1) * ptrStep;
                        var j1 =  xFlr      * ptrStep;
                        var j2 = (xFlr + 1) * ptrStep;
                        var j3 = (xFlr + 2) * ptrStep;

                        var p00 = i0 + j0; var p01 = i0 + j1; var p02 = i0 + j2; var p03 = i0 + j3;
                        var p10 = i1 + j0; var p11 = i1 + j1; var p12 = i1 + j2; var p13 = i1 + j3;
                        var p20 = i2 + j0; var p21 = i2 + j1; var p22 = i2 + j2; var p23 = i2 + j3;
                        var p30 = i3 + j0; var p31 = i3 + j1; var p32 = i3 + j2; var p33 = i3 + j3;

                        p0 = Interpolate(p00[0], p01[0], p02[0], p03[0], ref xFrc);
                        p1 = Interpolate(p10[0], p11[0], p12[0], p13[0], ref xFrc);
                        p2 = Interpolate(p20[0], p21[0], p22[0], p23[0], ref xFrc);
                        p3 = Interpolate(p30[0], p31[0], p32[0], p33[0], ref xFrc);

                        a = 0.5 * (-p0 + 3 * p1 - 3 * p2 + p3);
                        b = p0 + 2 * p2 - 0.5 * (5 * p1 + p3);
                        c = 0.5 * (-p0 + p2); d = p3;

                        point = yFrc * (yFrc * (a * yFrc + b) + c) + d;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[0] = (byte)point;

                        p0 = Interpolate(p00[1], p01[1], p02[1], p03[1], ref xFrc);
                        p1 = Interpolate(p10[1], p11[1], p12[1], p13[1], ref xFrc);
                        p2 = Interpolate(p20[1], p21[1], p22[1], p23[1], ref xFrc);
                        p3 = Interpolate(p30[1], p31[1], p32[1], p33[1], ref xFrc);

                        a = 0.5 * (-p0 + 3 * p1 - 3 * p2 + p3);
                        b = p0 + 2 * p2 - 0.5 * (5 * p1 + p3);
                        c = 0.5 * (-p0 + p2); d = p3;

                        point = yFrc * (yFrc * (a * yFrc + b) + c) + d;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[1] = (byte)point;

                        p0 = Interpolate(p00[2], p01[2], p02[2], p03[2], ref xFrc);
                        p1 = Interpolate(p10[2], p11[2], p12[2], p13[2], ref xFrc);
                        p2 = Interpolate(p20[2], p21[2], p22[2], p23[2], ref xFrc);
                        p3 = Interpolate(p30[2], p31[2], p32[2], p33[2], ref xFrc);

                        a = 0.5 * (-p0 + 3 * p1 - 3 * p2 + p3);
                        b = p0 + 2 * p2 - 0.5 * (5 * p1 + p3);
                        c = 0.5 * (-p0 + p2); d = p3;

                        point = yFrc * (yFrc * (a * yFrc + b) + c) + d;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[2] = (byte)point;
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        private double Interpolate(
            double p0, double p1,
            double p2, double p3,
            ref double t)
        {
            return t * (t * (
                0.5 * (-p0 + 3 * p1 - 3 * p2 + p3) * t +
                p0 + 2 * p2 - 0.5 * (5 * p1 + p3))
                + 0.5 * (-p0 + p2)) + p3;
        }
    }
}
