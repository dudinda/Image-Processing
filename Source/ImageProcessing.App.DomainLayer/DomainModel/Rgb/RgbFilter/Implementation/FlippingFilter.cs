using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    internal sealed class FlippingFilter : IRgbFilter
    {
        public Bitmap Filter(Bitmap bitmap)
        {
            var size = bitmap.Size;

            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var ptrStep = bitmap.GetBitsPerPixel() / 8;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var (width, height) = (size.Width, size.Height - 1);

            var endStride = bitmapData.Stride * height;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, width, options, x =>
                {
                    //get the address of a column
                    var start = startPtr + x * ptrStep;
                    var end = start + endStride;

                    byte tmp;

                    do
                    {
                        tmp = end[0];
                        end[0] = start[0];
                        start[0] = tmp;

                        tmp = end[1];
                        end[1] = start[1];
                        start[1] = tmp;

                        tmp = end[2];
                        end[2] = start[2];
                        start[2] = tmp;

                        start += bitmapData.Stride;
                        end -= bitmapData.Stride;

                    } while (start < end);
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
