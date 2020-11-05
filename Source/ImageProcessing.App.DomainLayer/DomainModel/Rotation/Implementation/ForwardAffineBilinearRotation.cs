using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation
{
    internal sealed class ForwardAffineRotation : IRotation
    {
        public Bitmap Rotate(Bitmap src, double rad)
        {
            if(rad == 0) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var (cos, sin) = (Math.Cos(rad), Math.Sin(rad));
      
            var (xUpRight, yUpRight) = ( srcWidth * cos, srcWidth * sin);
            var (xDoRight, yDoRight) = ( srcWidth * cos - srcHeight * sin, srcWidth * sin + srcHeight * cos);
            var (xDoLeft, yDoLeft) = (-srcHeight* sin, srcHeight * cos);
            
            var xMax = Math.Max(0, Math.Max(xUpRight, Math.Max(xDoRight, xDoLeft)));
            var xMin = Math.Min(0, Math.Min(xUpRight, Math.Min(xDoRight, xDoLeft)));
            var yMax = Math.Max(0, Math.Max(yUpRight, Math.Max(yDoRight, yDoLeft)));
            var yMin = Math.Min(0, Math.Min(yUpRight, Math.Min(yDoRight, yDoLeft)));

            var (dstHeight, dstWidth) = ((int)(yMax - yMin), (int)(xMax - xMin));

            var (xCenter, yCenter) = (dstWidth  / 2, dstHeight / 2);

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

                Parallel.For(0, dstWidth, options, y =>
                {
                    //get the address of a row
                    var dstPtr = dstStartPtr + y * dstData.Stride;
                    
                    for (var x = 0; x < dstWidth; ++x, dstPtr += ptrStep)
                    {
                        var newX = cos * (x - xCenter) - sin * (y - yCenter) + srcWidth  / 2.0;
                        var newY = sin * (x - xCenter) + cos * (y - yCenter) + srcHeight / 2.0;

                        var xFloor = (int)newX;
                        var yFloor = (int)newY;

                        var xFrac = newX - xFloor;
                        var yFrac = newY - yFloor;

                        if (xFloor < srcWidth  - 1 && xFloor > 0 &&
                            yFloor < srcHeight - 1 && yFloor > 0)
                        {
                            var i0 = srcStartPtr + yFloor * srcData.Stride;
                            var i1 = srcStartPtr + (yFloor + 1) * srcData.Stride;

                            var j0 = xFloor * ptrStep;
                            var j1 = (xFloor + 1) * ptrStep;

                            var p00 = i0 + j0; var p01 = i0 + j1;
                            var p10 = i1 + j0; var p11 = i1 + j1;

                            for (var index = 0; index < 3; ++index)
                            {
                                var col0 = p00[index] * (1 - xFrac) + p10[index] * xFrac;
                                var col1 = p01[index] * (1 - xFrac) + p11[index] * xFrac;

                                var point = col0 * (1 - yFrac) + col1 * yFrac;

                                if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                                dstPtr[index] = (byte)point;
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
