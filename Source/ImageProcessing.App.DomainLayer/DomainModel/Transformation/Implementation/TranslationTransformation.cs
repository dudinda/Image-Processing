using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    public sealed class TranslationTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double dx, double dy)
        {
            if (dx == 0 && dy == 0) { return src; }

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

            //(x, y) -> (x + x', y + y')
            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, srcHeight, options, y =>
                {
                    var newY = (int)(y + dy);

                    if (newY < srcHeight && newY >= 0)
                    {
                        //get the address of a row
                        var dstRow = dstStartPtr + newY * dstData.Stride;
                        var srcRow = srcStartPtr + y    * srcData.Stride;

                        for (var x = 0; x < srcWidth; ++x, srcRow += ptrStep)
                        {
                            var newX = (int)(x + dx);

                            if (newX < srcWidth && newX >= 0)
                            {
                                var dstPtr = dstRow + newX * ptrStep;

                                dstPtr[0] = srcRow[0];
                                dstPtr[1] = srcRow[1];
                                dstPtr[2] = srcRow[2];
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
