using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    internal sealed class BicubicInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double xScale, double yScale)
        {
            if(yScale == 0d && xScale == 0d) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var dstWidth = srcWidth + (int)(srcWidth * xScale);
            var dstHeight = srcHeight + (int)(srcHeight * yScale);

            if (dstWidth  <= 0) { throw new ArgumentException(nameof(xScale)); }
            if (dstHeight <= 0) { throw new ArgumentException(nameof(yScale)); }

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
                var (srcStride, dstStride) = (srcData.Stride, dstData.Stride);

                var dy = srcHeight / (double)dstHeight;
                var dx = srcWidth / (double)dstWidth;

                Parallel.For(0, dstHeight, options, y =>
                {
                    var newY = y * dy + 0.5;
                    var yFlr = (int)newY;
                    var yFrc = newY - yFlr;

                    if (yFlr <= 0) { yFlr = 1; } else if (yFlr > yBound) { yFlr = yBound; }

                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstStride;

                    var i0 = srcStartPtr + (yFlr - 1) * srcStride;
                    //srcStartPtr + yFlr * srcStide
                    var i1 = i0 + srcStride;
                    var i2 = i1 + srcStride;
                    var i3 = i2 + srcStride;

                    double point, newX, xFrc,
                           p0, p1, p2, p3,
                           a, b, c, d,
                           b0, b1, b2, b3;

                    byte* p00, p01, p02, p03,
                          p10, p11, p12, p13,
                          p20, p21, p22, p23,
                          p30, p31, p32, p33;

                    int j0, j1, j2, j3, xFlr;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        newX = x * dx + 0.5;
                        xFlr = (int)newX;
                        xFrc = newX - xFlr;

                        if (xFlr <= 0) { xFlr = 1; } else if (xFlr > xBound ) { xFlr = xBound; }

                        j0 = (xFlr - 1) * ptrStep;
                        //xFlr * ptrStrp
                        j1 = j0 + ptrStep;
                        j2 = j1 + ptrStep;
                        j3 = j2 + ptrStep;

                        p00 = i0 + j0; p01 = i0 + j1; p02 = i0 + j2; p03 = i0 + j3;
                        p10 = i1 + j0; p11 = i1 + j1; p12 = i1 + j2; p13 = i1 + j3;
                        p20 = i2 + j0; p21 = i2 + j1; p22 = i2 + j2; p23 = i2 + j3;
                        p30 = i3 + j0; p31 = i3 + j1; p32 = i3 + j2; p33 = i3 + j3;

                        //ax^3 + bx^2 + cx + d -> x * (x * (ax + b) + c) + d
                        //where a = (-0.5p0 + 1.5p1 - 1.5p2 + 0.5p3),
                        //      b = (p0 - 2.5p1 + 2p2 - 0.5p3),
                        //      c = (-0.5p0 + 0.5p2), d = p1

                        b0 = p00[0]; b1 = p01[0]; b2 = p02[0]; b3 = p03[0];

                        p0 = xFrc * (xFrc * (
                             0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                             b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                             + 0.5 * (-b0 + b2)) + b1;

                        b0 = p10[0]; b1 = p11[0]; b2 = p12[0]; b3 = p13[0];

                        p1 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        b0 = p20[0]; b1 = p21[0]; b2 = p22[0]; b3 = p23[0];

                        p2 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        b0 = p30[0]; b1 = p31[0]; b2 = p32[0]; b3 = p33[0];

                        p3 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        a = 0.5 * (-p0 + 3.0 * p1 - 3.0 * p2 + p3);
                        b = p0 + 2.0 * p2 - 0.5 * (5.0 * p1 + p3);
                        c = 0.5 * (-p0 + p2); d = p1;

                        point = yFrc * (yFrc * (a * yFrc + b) + c) + d;

                        if (point > 255d) { point = 255d; } else if (point < 0d) { point = 0d; }

                        dstRow[0] = (byte)point;

                        b0 = p00[1]; b1 = p01[1]; b2 = p02[1]; b3 = p03[1];

                        p0 = xFrc * (xFrc * (
                             0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                             b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                             + 0.5 * (-b0 + b2)) + b1;

                        b0 = p10[1]; b1 = p11[1]; b2 = p12[1]; b3 = p13[1];

                        p1 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        b0 = p20[1]; b1 = p21[1]; b2 = p22[1]; b3 = p23[1];

                        p2 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        b0 = p30[1]; b1 = p31[1]; b2 = p32[1]; b3 = p33[1];

                        p3 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        a = 0.5 * (-p0 + 3.0 * p1 - 3.0 * p2 + p3);
                        b = p0 + 2.0 * p2 - 0.5 * (5.0 * p1 + p3);
                        c = 0.5 * (-p0 + p2); d = p1;

                        point = yFrc * (yFrc * (a * yFrc + b) + c) + d;

                        if (point > 255d) { point = 255d; } else if (point < 0d) { point = 0d; }

                        dstRow[1] = (byte)point;

                        b0 = p00[2]; b1 = p01[2]; b2 = p02[2]; b3 = p03[2];

                        p0 = xFrc * (xFrc * (
                             0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                             b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                             + 0.5 * (-b0 + b2)) + b1;

                        b0 = p10[2]; b1 = p11[2]; b2 = p12[2]; b3 = p13[2];

                        p1 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        b0 = p20[2]; b1 = p21[2]; b2 = p22[2]; b3 = p23[2];

                        p2 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        b0 = p30[2]; b1 = p31[2]; b2 = p32[2]; b3 = p33[2];

                        p3 = xFrc * (xFrc * (
                            0.5 * xFrc * (-b0 + 3.0 * b1 - 3.0 * b2 + b3) +
                            b0 + 2.0 * b2 - 0.5 * (5.0 * b1 + b3))
                            + 0.5 * (-b0 + b2)) + b1;

                        a = 0.5 * (-p0 + 3.0 * p1 - 3.0 * p2 + p3);
                        b = p0 + 2.0 * p2 - 0.5 * (5.0 * p1 + p3);
                        c = 0.5 * (-p0 + p2); d = p1;

                        point = yFrc * (yFrc * (a * yFrc + b) + c) + d;

                        if (point > 255d) { point = 255d; } else if (point < 0d) { point = 0d; }

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
