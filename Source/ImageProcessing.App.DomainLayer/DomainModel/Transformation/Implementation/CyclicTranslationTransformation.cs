using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    public sealed class CyclicTranslationTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double x, double y)
        {
            if (x == 0 && y == 0)
            { return src; }

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
            var (dx, dy) = (x, y);
   
            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, srcHeight, options, y =>
                {
                    var newY = y + dy;

                    //y' mod height
                    if (newY < 0 || newY >= srcHeight)
                    {
                        newY = newY - srcHeight * Math.Floor(newY / srcHeight);
                    }

                    //get the address of a row
                    var dstRow = dstStartPtr + (int)newY * dstData.Stride;
                    var srcRow = srcStartPtr + y * srcData.Stride;

                    for (var x = 0; x < srcWidth; ++x, srcRow += ptrStep)
                    {
                        var newX = x + dx;

                        //x' mod width
                        if (newX < 0 || newX >= srcWidth)
                        {
                            newX = newX - srcWidth * Math.Floor(newX / srcWidth);
                        }
          
                        var dstPtr = dstRow + (int)newX * ptrStep;

                        dstPtr[0] = srcRow[0];
                        dstPtr[1] = srcRow[1];
                        dstPtr[2] = srcRow[2];
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

    }
}
