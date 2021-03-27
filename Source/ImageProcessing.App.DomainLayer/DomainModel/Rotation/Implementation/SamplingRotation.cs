using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation
{
    internal sealed class SamplingRotation : IRotation
    {
        public Bitmap Rotate(Bitmap src, double rad)
        {
            if (rad == 0d) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var (cos, sin) = (Math.Cos(rad), Math.Sin(rad));

            var (xUpRight, yUpRight) = (srcWidth * cos, srcWidth * sin);
            var (xDoRight, yDoRight) = (srcWidth * cos - srcHeight * sin, srcWidth * sin + srcHeight * cos);
            var (xDoLeft, yDoLeft) = (-srcHeight * sin, srcHeight * cos);

            var xMax = Math.Max(0, Math.Max(xUpRight, Math.Max(xDoRight, xDoLeft)));
            var xMin = Math.Min(0, Math.Min(xUpRight, Math.Min(xDoRight, xDoLeft)));
            var yMax = Math.Max(0, Math.Max(yUpRight, Math.Max(yDoRight, yDoLeft)));
            var yMin = Math.Min(0, Math.Min(yUpRight, Math.Min(yDoRight, yDoLeft)));

            var (dstHeight, dstWidth) = ((int)(yMax - yMin), (int)(xMax - xMin));
            var (dSrcWidth, dSrcHeight) = ((double)srcWidth, (double)srcHeight);

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
               .DrawFilledRectangle(Brushes.White);

            var (xCenter, yCenter) = ((dstWidth - 1) / 2.0, (dstHeight - 1) / 2.0);
            var (xSrcCenter, ySrcCenter) = ((srcWidth - 1) / 2.0, (srcHeight - 1) / 2.0);

            var srcData = src.LockBits(
                new Rectangle(0, 0, srcWidth, srcHeight),
                ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dstWidth, dstHeight),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var ptrStep = src.GetBitsPerPixel() / 8;
            var (srcStride, dstStride) = (srcData.Stride, dstData.Stride);

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            //inv( T(x, y)S(alpha)inv(T(x', y')) )v = v'
            //where x and y are the center of a destination and x' and y' are the
            //center of a source and S is a rotation matrix
            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, dstHeight, options, y =>
                {
                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstStride;

                    var yShift = y - yCenter;

                    double xShift, srcX, srcY;

                    byte* srcPtr;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        xShift = x - xCenter;

                        srcX = cos * xShift - sin * yShift + xSrcCenter;
                        srcY = sin * xShift + cos * yShift + ySrcCenter;

                        if (srcX < dSrcWidth  && srcX > 0d &&
                            srcY < dSrcHeight && srcY > 0d)
                        {
                            srcPtr = srcStartPtr + (int)srcY * srcStride + (int)srcX * ptrStep;

                            dstRow[0] = srcPtr[0];
                            dstRow[1] = srcPtr[1];
                            dstRow[2] = srcPtr[2];
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
