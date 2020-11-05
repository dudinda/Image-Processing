using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    internal sealed class ProximalInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double yScale, double xScale)
        {
            if(yScale == 0 && xScale == 0) { return src; } 

            var dstWidth  = src.Width  + (int)(src.Width  * xScale);
            var dstHeight = src.Height + (int)(src.Height * yScale);

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
                .DrawFilledRectangle(Brushes.White);

            if(src.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                return Resize8bpp(src, dst, yScale, xScale);
            } 

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

                var yCoef = src.Height / (double)dstHeight;
                var xCoef = src.Width  / (double)dstWidth;

                Parallel.For(0, dstHeight, options, y =>
                {
                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;
                    var srcRow = srcStartPtr + (int)(y * yCoef) * srcData.Stride;
     
                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        var srcPtr = srcRow + (int)(x * xCoef) * ptrStep;

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

        private Bitmap Resize8bpp(
           Bitmap src, Bitmap dst,
           double yScale, double xScale)
        {
            var dstWidth = dst.Width;
            var dstHeight = dst.Height;

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

                var yCoef = src.Height / (double)dstHeight;
                var xCoef = src.Width / (double)dstWidth;

                Parallel.For(0, dstHeight, options, y =>
                {
                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;
                    var srcRow = srcStartPtr + (int)(y * yCoef) * srcData.Stride;

                    for (var x = 0; x < dstWidth; ++x, ++dstRow)
                    {
                        var srcPtr = srcRow + (int)(x * xCoef) * ptrStep;

                        dstRow[0] = srcPtr[0];
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
    }
}
