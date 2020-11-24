using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    internal sealed class FloppingFilter : IRgbFilter
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
                
                Parallel.For(0, size.Height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * bitmapData.Stride;
                    var endPtr = ptr + bitmapData.Stride - ptrStep;
 
                    do
                    {
                        (ptr[0], endPtr[0]) = (endPtr[0], ptr[0]);
                        (ptr[1], endPtr[1]) = (endPtr[1], ptr[1]);
                        (ptr[2], endPtr[2]) = (endPtr[2], ptr[2]);

                        ptr += ptrStep;
                        endPtr -= ptrStep;

                    } while (ptr < endPtr);
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
