using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    public sealed class CyclicTranslationTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double tx, double ty)
        {
            if (src is null) { throw new ArgumentNullException(nameof(src)); }
            if (src.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            if (tx == 0d && ty == 0d) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);
            var (dSrcWidth, dSrcHeight) = ((double)srcWidth, (double)srcHeight);

            var dst = new Bitmap(srcWidth, srcHeight, src.PixelFormat)
              .DrawFilledRectangle(Brushes.White);

            var srcData = src.LockBits(
              new Rectangle(0, 0, srcWidth, srcHeight),
              ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, srcWidth, srcHeight),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var (srcStride, dstStride) = (srcData.Stride, dstData.Stride);

            //inv(A)v  = v',
            //where A is a translation matrix
            // and v' = (x' mod width, y' mod height) 
            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, srcHeight, options, y =>
                {
                    var srcY = y - ty;

                    //y' mod height
                    if (srcY < 0d || srcY >= dSrcHeight)
                    {
                        srcY = srcY - dSrcHeight * Math.Floor(srcY / dSrcHeight);
                    }

                    //get the address of a row
                    var srcRow = srcStartPtr + (int)srcY * srcStride;
                    var dstRow = dstStartPtr +         y * dstStride;

                    double srcX;

                    byte* srcPtr;

                    for (var x = 0; x < srcWidth; ++x, dstRow += step)
                    {
                        srcX = x - tx;

                        //x' mod width
                        if (srcX < 0d || srcX >= dSrcWidth)
                        {
                            srcX = srcX - dSrcWidth * Math.Floor(srcX / dSrcWidth);
                        }
          
                        srcPtr = srcRow + (int)srcX * step;

                        dstRow[0] = srcPtr[0];
                        dstRow[1] = srcPtr[1];
                        dstRow[2] = srcPtr[2];
                        dstRow[3] = srcPtr[3];
                    }
                });
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
    }
}
