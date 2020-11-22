using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    internal sealed class ScaleTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double sx, double sy)
        {
            if (sx == 1 && sy == 1) { return src; }

            if (sx == 0 || sy == 0)
            {
                throw new ArgumentException();
            }

            var dstWidth = src.Width + (int)(src.Width * sx);
            var dstHeight = src.Height + (int)(src.Height * sy);

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
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

                var (srcWidth, srcHeight) = (src.Width, src.Height);

                //inv(A)v = v'
                // where A is a scale matrix
                Parallel.For(0, dstHeight, options, y =>
                {
                    var srcY = y / sy;

                    if (srcY < srcHeight && srcY >= 0)
                    {
                        //get the address of a row
                        var dstRow = dstStartPtr +         y * dstData.Stride;
                        var srcRow = srcStartPtr + (int)srcY * srcData.Stride;

                        for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                        {
                            var srcX = x / sx;

                            if (srcX < srcWidth && srcX >= 0)
                            {
                                var srcPtr = srcRow + (int)srcX * ptrStep;

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
