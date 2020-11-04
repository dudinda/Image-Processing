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
            var dstWidth = src.Size.Width + (int)(src.Size.Width * xScale);
            var dstHeight = src.Size.Height + (int)(src.Size.Height * yScale);

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

                var yCoef = (src.Height - 1) / (double)dstHeight;
                var xCoef = (src.Width - 1) / (double)dstWidth;

                var srcWidth = src.Size.Width - 1;
                var srcHeight = src.Size.Height - 1;

                Parallel.For(0, dstHeight, options, y =>
                {
                    var newY      = y * yCoef;
                    var newYFloor = (int)newY;
                    var newYFrac  = newY - newYFloor;

                    if (newY >= srcHeight) { newY = srcHeight - 1; }

                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstData.Stride;

                    var i0 = srcStartPtr + newYFloor       * srcData.Stride;
                    var i1 = srcStartPtr + (newYFloor + 1) * srcData.Stride;
                    
                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    { 
                        var newX      = x * xCoef;
                        var newXFloor = (int)newX;
                        var newXFrac  = newX - newXFloor;

                        if (newXFloor >= srcWidth) { newXFloor = srcWidth - 1; }

                        var j0 = newXFloor       * ptrStep;
                        var j1 = (newXFloor + 1) * ptrStep;

                        var p00 = i0 + j0; var p10 = i1 + j0;                      
                        var p01 = i0 + j1; var p11 = i1 + j1;

                        for(var index = 0; index < 3; ++index)
                        {
                            var col0 = p00[index] * (1 - newXFrac) + p10[index] * newXFrac;
                            var col1 = p01[index] * (1 - newXFrac) + p11[index] * newXFrac;

                            var point = col0 * (1 - newYFrac) + col1 * newYFrac;

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
