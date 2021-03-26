using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    public sealed class TranslationTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double tx, double ty)
        {
            if (tx == 0d && ty == 0d) { return src; }

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

            //inv(A)v = v',
            //where A is a translation matrix
            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, srcHeight, options, y =>
                {
                    var srcY = y - ty;

                    if (srcY < srcHeight && srcY >= 0d)
                    {
                        //get the address of a row
                        var dstRow = dstStartPtr + y * dstData.Stride;
                        var srcRow = srcStartPtr + (int)srcY * srcData.Stride;

                        double srcX;

                        byte* srcPtr;

                        for (var x = 0; x < srcWidth; ++x, dstRow += ptrStep)
                        {
                            srcX = x - tx;

                            if (srcX < srcWidth && srcX >= 0d)
                            {
                                srcPtr = srcRow + (int)srcX * ptrStep;

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
