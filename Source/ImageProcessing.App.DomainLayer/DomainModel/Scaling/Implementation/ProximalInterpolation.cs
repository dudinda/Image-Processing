using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    public sealed class ProximalInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double yScale, double xScale)
        {
            var targetWidth =  src.Size.Width + (int)(src.Size.Width  * xScale);
            var targetHeight = src.Size.Height+ (int)(src.Size.Height * yScale);

            var dst = new Bitmap(targetWidth, targetHeight, src.PixelFormat)
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

                var yCoef = (src.Height - 1) / (double)targetHeight;
                var xCoef = (src.Width - 1) / (double)targetWidth;

                Parallel.For(0, targetHeight, options, y =>
                {
                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;
                    var srcRow = srcStartPtr + (int)(y * yCoef) * srcData.Stride;
     
                    for (var x = 0; x < targetWidth; ++x, dstRow += ptrStep)
                    {
                        var srcPtr = srcRow + ((int)(x * xCoef) * ptrStep);

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
