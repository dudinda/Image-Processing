using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation
{
    internal sealed class AreaMappingRotation : IRotation
    {
        public Bitmap Rotate(Bitmap src, double rad)
        {
            if(rad == 0) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var (cos, sin) = (Math.Cos(rad), Math.Sin(rad));
      
            var (xUpRight, yUpRight) = (srcWidth * cos, srcWidth * sin);
            var (xDoRight, yDoRight) = (srcWidth * cos - srcHeight * sin, srcWidth * sin + srcHeight * cos);
            var (xDoLeft, yDoLeft) = (-srcHeight* sin, srcHeight * cos);
            
            var xMax = Math.Max(0, Math.Max(xUpRight, Math.Max(xDoRight, xDoLeft)));
            var xMin = Math.Min(0, Math.Min(xUpRight, Math.Min(xDoRight, xDoLeft)));
            var yMax = Math.Max(0, Math.Max(yUpRight, Math.Max(yDoRight, yDoLeft)));
            var yMin = Math.Min(0, Math.Min(yUpRight, Math.Min(yDoRight, yDoLeft)));

            var (dstHeight, dstWidth) = ((int)(yMax - yMin), (int)(xMax - xMin));

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
               .DrawFilledRectangle(Brushes.White);

            var (xCenter, yCenter) = ((dstWidth + 1) / 2.0, (dstHeight + 1) / 2.0);
            var (xSrcCenter, ySrcCenter) = ((srcWidth + 1) / 2.0, (srcHeight + 1) / 2.0);

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

            //inv( T(x, y)S(alpha)inv(T(x', y')) )v = v'
            //where x and y are the center of a destination and x' and y' are the
            //center of a source and S is a rotation matrix
            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, dstWidth, options, y =>
                {
                    //get the address of a row
                    var dstPtr = dstStartPtr + y * dstData.Stride;

                    var yShift = y - yCenter;

                    double col0, col1, point;

                    for (var x = 0; x < dstWidth; ++x, dstPtr += ptrStep)
                    {
                        var xShift = x - xCenter; 

                        var newX = cos * xShift - sin * yShift + xSrcCenter;
                        var newY = sin * xShift + cos * yShift + ySrcCenter;

                        var xFloor = (int)newX;
                        var yFloor = (int)newY;

                        var xFrac = newX - xFloor;
                        var yFrac = newY - yFloor;

                        if (xFloor < srcWidth  && xFloor > 0 &&
                            yFloor < srcHeight && yFloor > 0)
                        {
                            var i0 = srcStartPtr + yFloor       * srcData.Stride;
                            var i1 = srcStartPtr + (yFloor + 1) * srcData.Stride;

                            var j0 = xFloor * ptrStep;
                            var j1 = (xFloor + 1) * ptrStep;

                            var p00 = i0 + j0; var p01 = i0 + j1;
                            var p10 = i1 + j0; var p11 = i1 + j1;

                            var invXFrac = 1 - xFrac;
                            var invYFrac = 1 - yFrac;

                            col0 = p00[0] * invXFrac + p10[0] * xFrac;
                            col1 = p01[0] * invXFrac + p11[0] * xFrac;

                            point = col0 * invYFrac + col1 * yFrac;

                            if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                            dstPtr[0] = (byte)point;

                            col0 = p00[1] * invXFrac + p10[1] * xFrac;
                            col1 = p01[1] * invXFrac + p11[1] * xFrac;

                            point = col0 * invYFrac + col1 * yFrac;

                            if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                            dstPtr[1] = (byte)point;

                            col0 = p00[2] * invXFrac + p10[2] * xFrac;
                            col1 = p01[2] * invXFrac + p11[2] * xFrac;

                            point = col0 * invYFrac + col1 * yFrac;

                            if (point > 255) { point = 255; } else if (point < 0) { point = 0; }

                            dstPtr[2] = (byte)point;
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
