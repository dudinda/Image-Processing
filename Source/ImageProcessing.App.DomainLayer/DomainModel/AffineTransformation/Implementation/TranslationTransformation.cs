using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.AffineTransformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.AffineTransformation.Implementation
{
    internal sealed class TranslationTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double x, double y)
        {
            if (x == 0 && y == 0) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var dst = new Bitmap(srcWidth, srcHeight, src.PixelFormat)
              .DrawFilledRectangle(Brushes.White);

            var srcData = src.LockBits(
              new Rectangle(0, 0, srcWidth, srcHeight),
              ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, srcWidth, srcHeight),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var ptrStep = src.GetBitsPerPixel() / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var (dx, dy) = (x, y);

            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, srcHeight, options, y =>
                {
                    var newY = (int)(y - dy);

                    if (newY < srcHeight && newY >= 0)
                    {
                        //get the address of a row
                        var dstRow = dstStartPtr + y * dstData.Stride;
                        var srcRow = srcStartPtr + newY * srcData.Stride;

                        for (var x = 0; x < srcWidth; ++x, dstRow += ptrStep)
                        {
                            var newX = (int)(x - dx);

                            if (newX < srcWidth && newX >= 0)
                            {
                                var srcPtr = srcRow + newX * ptrStep;

                                dstRow[0] = srcPtr[0];
                                dstRow[1] = srcPtr[1];
                                dstRow[2] = srcPtr[2];
                            }
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
