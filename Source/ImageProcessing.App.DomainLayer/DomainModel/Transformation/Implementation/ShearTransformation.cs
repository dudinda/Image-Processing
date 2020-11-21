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

            var dstWidth = (int)(srcWidth + Math.Abs(dx) * srcHeight);
            var dstHeight = (int)(srcHeight + Math.Abs(dy) * srcWidth);

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

            var (xOffset, yOffset) = ((int)(dx * srcHeight), (int)(dy * srcWidth));

            if(dx > 0) { xOffset = 0; }
            if(dy > 0) { yOffset = 0; }

            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                //inv(A)v = v'
                // where A is a shear matrix
                // if the offset is negative, then translate the
                // source forward by inv(A)Bv = v'
                // where B is a translation matrix
                var detA = 1 - dx * dy;

                Parallel.For(0, dstHeight, options, y =>
                {                 
                    //get the address of a row
                    var dstRow = dstStartPtr + y *dstData.Stride;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        var shiftX = x + xOffset;
                        var shiftY = y + yOffset;

                        // 1 / det(A)  * adj(A)Bv = v'
                        var srcX = (int)((shiftX - dx * shiftY) / detA);
                        var srcY = (int)((shiftY - dy * shiftX) / detA);
                
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
