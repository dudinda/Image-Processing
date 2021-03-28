using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation
{
    internal sealed class ShearRotation : IRotation
    {
        public Bitmap Rotate(Bitmap src, double rad)
        {
            if(rad == 0d) { return src; }

            var (srcWidth, srcHeight) = (src.Width, src.Height);

            var (cos, sin) = (Math.Cos(rad), Math.Sin(rad));

            var (xUpRight, yUpRight) = (srcWidth * cos, srcWidth * sin);
            var (xDoRight, yDoRight) = (srcWidth * cos - srcHeight * sin, srcWidth * sin + srcHeight * cos);
            var (xDoLeft, yDoLeft) = (-srcHeight * sin, srcHeight * cos);

            var xMax = Math.Max(0, Math.Max(xUpRight, Math.Max(xDoRight, xDoLeft)));
            var xMin = Math.Min(0, Math.Min(xUpRight, Math.Min(xDoRight, xDoLeft)));
            var yMax = Math.Max(0, Math.Max(yUpRight, Math.Max(yDoRight, yDoLeft)));
            var yMin = Math.Min(0, Math.Min(yUpRight, Math.Min(yDoRight, yDoLeft)));

            var (dstHeight, dstWidth) = ((int)(yMax - yMin), (int)(xMax - xMin));
            var (dSrcWidth, dSrcHeight) = ((double)srcWidth, (double)srcHeight);

            var (xCenter, yCenter) = ((dstWidth - 1) / 2.0, (dstHeight - 1) / 2.0);
            var (xSrcCenter, ySrcCenter) = ((srcWidth - 1) / 2.0, (srcHeight - 1) / 2.0);

            var dst = new Bitmap(dstWidth, dstHeight, src.PixelFormat)
              .DrawFilledRectangle(Brushes.White);

            //if tan(rad/2) tends to inf, substract the epsilon value
            //alpha is computed as tan(rad/2) so calculate tan(rad mod pi) instead
            if(rad - Math.PI * (rad / Math.PI) < 10e-12)
            {
                rad = Math.Sign(rad) * (Math.Abs(rad) - 10e-12);
            }  

            // inv(Sh(a, 0)) = Sh(-a , 0)
            // inv(Sh(0, b)) = Sh(0, -b)
            var alpha = -Math.Tan(rad / 2d);
            var beta  = Math.Sin(rad);

            var srcData = src.LockBits(
                 new Rectangle(0, 0, srcWidth, srcHeight),
                 ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dstWidth, dstHeight),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var ptrStep = src.GetBitsPerPixel() / 8;
            var (srcStride, dstStride) = (srcData.Stride, dstData.Stride);

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            //inv( T(x, y)Sh(alpha, 0)Sh(0, beta)Sh(gamma, 0)inv(T(x', y')) )v = v'
            //where x and y are the center of a destination and x' and y' are the
            //center of a source and Sh(shx, shy) is a shear matrix and T(x, y) is
            //a translation matrix.
            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();

                Parallel.For(0, dstHeight, options, y =>
                {
                    //get the address of a row
                    var dstRow = dstStartPtr + y * dstStride;

                    var yShift = y - yCenter;

                    double xShift, srcX, srcY;

                    byte* srcPtr;

                    for (var x = 0; x < dstWidth; ++x, dstRow += ptrStep)
                    {
                        //inv(T(x, y))v = m
                        xShift = x - xCenter;

                        //inv(Sh(alpha, 0))m = m'
                        srcX = xShift + alpha * yShift;

                        //inv(Sh(0, beta))m' = m''
                        srcY = yShift + beta * srcX;

                        //inv(Sh(gamma, 0))inv(T(x', y'))m'' = v'
                        srcX += alpha * srcY + xSrcCenter;
                        srcY += ySrcCenter;

                        if (srcX < dSrcWidth  && srcX >= 0d &&
                            srcY < dSrcHeight && srcY >= 0d)
                        {
                            srcPtr = srcStartPtr + (int)srcY * srcStride + (int)srcX * ptrStep;

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
