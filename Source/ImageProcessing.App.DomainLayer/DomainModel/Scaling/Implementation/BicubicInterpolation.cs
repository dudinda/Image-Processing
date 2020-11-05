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
        public Bitmap Resize(Bitmap src, double yScale, double xScale)
        {
            var dstWidth = src.Width + (int)(src.Width * xScale);
            var dstHeight = src.Height + (int)(src.Height * yScale);

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

                // guarantees that on coordinate transform (x, y) -> (ax, ay)
                // the pointer of the source image will not reach
                // the two rightmost columns and the two lowest rows
                var srcWidth = src.Width - 2;
                var srcHeight = src.Height - 2;

                var yCoef = srcHeight / (double)dstHeight;
                var xCoef = srcWidth / (double)dstWidth;

                Parallel.For(0, dstHeight, options, y =>
                {
                    var newY = y * yCoef;
                    var yFlr = (int)newY;
                    var yFrc = newY - yFlr;

                    if (yFlr <= 0) { yFlr = 1; } 

                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;

                    var i0 = srcStartPtr + (yFlr - 1) * srcData.Stride;
                    var i1 = srcStartPtr +  yFlr      * srcData.Stride;
                    var i2 = srcStartPtr + (yFlr + 1) * srcData.Stride;
                    var i3 = srcStartPtr + (yFlr + 2) * srcData.Stride;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {                      
                        var newX = x * xCoef;
                        var xFlr = (int)newX;
                        var xFrc = newX - xFlr;

                        if (xFlr <= 0) { xFlr = 1; }

                        var j0 = (xFlr - 1) * ptrStep;
                        var j1 =  xFlr      * ptrStep;
                        var j2 = (xFlr + 1) * ptrStep;
                        var j3 = (xFlr + 2) * ptrStep;

                        var p00 = i0 + j0; var p01 = i0 + j1; var p02 = i0 + j2; var p03 = i0 + j3;
                        var p10 = i1 + j0; var p11 = i1 + j1; var p12 = i1 + j2; var p13 = i1 + j3;
                        var p20 = i2 + j0; var p21 = i2 + j1; var p22 = i2 + j2; var p23 = i2 + j3;
                        var p30 = i3 + j0; var p31 = i3 + j1; var p32 = i3 + j2; var p33 = i3 + j3;

                        for (var index = 0; index < 3; ++index)
                        {
                            var p1 = Interpolate(p00[index], p01[index], p02[index], p03[index], ref xFrc);
                            var p2 = Interpolate(p10[index], p11[index], p12[index], p13[index], ref xFrc);
                            var p3 = Interpolate(p20[index], p21[index], p22[index], p23[index], ref xFrc);
                            var p4 = Interpolate(p30[index], p31[index], p32[index], p33[index], ref xFrc);

                            var a = 0.5 * (-p1 + 3 * p2 - 3 * p3 + p4);
                            var b = p1 + 2 * p3 - 0.5 * (5 * p2 + p4);
                            var c = 0.5 * (-p1 + p3);
                            var d = p4;

                            var point = yFrc * (yFrc * (a * yFrc + b) + c) + d;

                            if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                            dstRow[index] = (byte)point;
                        }
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;

            double Interpolate(double p0, double p1, double p2, double p3, ref double t)
            {
                var a = 0.5 * (-p0 + 3 * p1 - 3 * p2 + p3);
                var b = p0 + 2 * p2 - 0.5 * (5 * p1 + p3);
                var c = 0.5 * (-p0 + p2);
                var d = p3;

                return t * (t * (a * t + b) + c) + d;
            }
        }
    }
}
