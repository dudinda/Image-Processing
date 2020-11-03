using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    public sealed class BilinearInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double yScale, double xScale)
        {
            var targetWidth = src.Size.Width + (int)(src.Size.Width * xScale);
            var targetHeight = src.Size.Height + (int)(src.Size.Height * yScale);

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
                    var newY = (int)(y * yCoef);
                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;

                    var srcUpRow = srcStartPtr + newY       * srcData.Stride;
                    var srcLoRow = srcStartPtr + (newY + 1) * srcData.Stride;
                    
                    for (var x = 0; x < targetWidth; ++x, dstRow += ptrStep)
                    {
                        var xFrac = xCoef % 1;
                        var yFrac = yCoef % 1;

                        var newX = (int)(x * xCoef);

                        var srcLeCol = newX       * ptrStep;
                        var srcRaCol = (newX + 1) * ptrStep;

                        var p00 = srcLeCol + srcUpRow; // (0, 0)
                        var p10 = srcRaCol + srcUpRow; // (1, 0)
                        var p01 = srcLeCol + srcLoRow; // (0, 1)
                        var p11 = srcRaCol + srcLoRow; // (1, 1)

                        for(var index = 0; index < 3; ++index)
                        {
                            var col0 = p00[index] * (1 - xFrac) + p10[index] * xFrac;
                            var col1 = p01[index] * (1 - xFrac) + p11[index] * xFrac;

                            var point = col0 * (1 - yFrac) + col1 * yFrac;

                            if (point > 255)
                            {
                                point = 255;
                            }
                               
                            if (point < 0)
                            {
                                point = 0;
                            }

                            dstRow[index] = (byte)point;
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
