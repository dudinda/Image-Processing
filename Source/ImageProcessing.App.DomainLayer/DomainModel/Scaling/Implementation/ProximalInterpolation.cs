using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    internal sealed class ProximalInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double xScale, double yScale)
        {
            if(yScale == 0d && xScale == 0d) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var dstWidth  = srcWidth  + (int)(srcWidth  * xScale);
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

                var dy = srcHeight / (double)dstHeight;
                var dx = srcWidth  / (double)dstWidth;

                Parallel.For(0, dstHeight, options, y =>
                {
                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;
                    var srcRow = srcStartPtr + (int)(y * dy) * srcData.Stride;

                    byte* srcPtr;
     
                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        srcPtr = srcRow + (int)(x * dx) * ptrStep;

                        dstRow[0] = srcPtr[0];
                        dstRow[1] = srcPtr[1];
                        dstRow[2] = srcPtr[2];
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
    }
}
