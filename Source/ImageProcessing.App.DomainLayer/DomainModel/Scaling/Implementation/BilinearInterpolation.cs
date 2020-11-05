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
        public Bitmap Resize(Bitmap src, double yScale, double xScale)
        {
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

                // guarantees that on coordinate transform (x, y) -> (ax, ay)
                // the pointer of the source image will not reach
                // the rightmost column and the lowest row
                var srcWidth = src.Width - 1;
                var srcHeight = src.Height - 1;

                var yCoef = srcHeight / (double)dstHeight;
                var xCoef = srcWidth / (double)dstWidth;

                var setStep = ptrStep;

                Parallel.For(0, dstHeight, options, y =>
                {
                    var newY      = y * yCoef;
                    var newYFloor = (int)newY;
                    var newYFrac  = newY - newYFloor;

                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;

                    var i0 = srcStartPtr + newYFloor       * srcData.Stride;
                    var i1 = srcStartPtr + (newYFloor + 1) * srcData.Stride;

                    double col0, col1, point;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    { 
                        var newX      = x * xCoef;
                        var newXFloor = (int)newX;
                        var newXFrac  = newX - newXFloor;

                        var j0 = newXFloor       * ptrStep;
                        var j1 = (newXFloor + 1) * ptrStep;

                        var p00 = i0 + j0; var p10 = i1 + j0;                      
                        var p01 = i0 + j1; var p11 = i1 + j1;

                        var invXFrac = 1 - newXFrac;
                        var invYFrac = 1 - newYFrac;

                        col0 = p00[0] * invXFrac + p10[0] * newXFrac;
                        col1 = p01[0] * invXFrac + p11[0] * newXFrac;

                        point = col0 * invYFrac + col1 * newYFrac;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[0] = (byte)point;

                        col0 = p00[1] * invXFrac + p10[1] * newXFrac;
                        col1 = p01[1] * invXFrac + p11[1] * newXFrac;

                        point = col0 * invYFrac + col1 * newYFrac;

                        if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                        dstRow[1] = (byte)point;

                        col0 = p00[2] * invXFrac + p10[2] * newXFrac;
                        col1 = p01[2] * invXFrac + p11[2] * newXFrac;

                        point = col0 * invYFrac + col1 * newYFrac;

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
