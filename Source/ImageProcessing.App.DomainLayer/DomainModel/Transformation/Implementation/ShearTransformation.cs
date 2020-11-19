using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    internal sealed class ShearTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double dx, double dy)
        {
            if (dx == 0 && dy == 0) { return src; }

            if(dx == 1 && dy == 1)
            {
                throw new InvalidOperationException();
            }

            var (srcWidth, srcHeight) = (src.Width, src.Height);
            var (dstWidth, dstHeight) = ((int)(srcWidth + dx * srcHeight), (int)(srcHeight + dy * srcWidth));

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
              .DrawFilledRectangle(Brushes.White);

            var srcData = src.LockBits(
              new Rectangle(0, 0, srcWidth, srcHeight),
              ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dstWidth, dstHeight),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var ptrStep = src.GetBitsPerPixel() / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                //inv(A)v = v'
                // where A is a shear matrix
                var detA = dx * dy - 1;

                Parallel.For(0, dstHeight, options, y =>
                {                 
                    //get the address of a row
                    var dstRow = dstStartPtr + y *dstData.Stride;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        var srcX = (int)((dx * y - x) / detA);
                        var srcY = (int)((dy * x - y) / detA);
                
                        if (srcX < srcWidth  && srcX >= 0 &&
                            srcY < srcHeight && srcY >= 0)
                        {
                            var srcPtr = srcStartPtr + srcY * srcData.Stride + srcX * ptrStep;

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
