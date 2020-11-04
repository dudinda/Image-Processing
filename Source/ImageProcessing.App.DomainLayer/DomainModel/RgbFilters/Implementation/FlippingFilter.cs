using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation
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

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Width, options, x =>
                {
                    //get the address of a column
                    var ptr = startPtr + x * ptrStep;
                    var endPtr = ptr + bitmapData.Stride * (size.Height - 1);

                    do
                    {
                        (ptr[0], endPtr[0]) = (endPtr[0], ptr[0]);
                        (ptr[1], endPtr[1]) = (endPtr[1], ptr[1]);
                        (ptr[2], endPtr[2]) = (endPtr[2], ptr[2]);

                        ptr += bitmapData.Stride;
                        endPtr -= bitmapData.Stride;

                    } while (ptr < endPtr);
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
