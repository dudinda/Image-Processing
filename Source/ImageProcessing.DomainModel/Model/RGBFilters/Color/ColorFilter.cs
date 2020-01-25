using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Core.Model.RGBFilters;

namespace ImageProcessing.RGBFilters.Color
{
    public class ColorFilter : IRGBFilter
    {
        IColor _filter;
        public ColorFilter(IColor filter)
        {
            _filter = filter;
        }

        public Bitmap Filter(Bitmap bitmap)
        {
            if(bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                             ImageLockMode.ReadWrite,
                                             bitmap.PixelFormat);

            var size = bitmap.Size;
            var ptrStep = bitmap.GetBitsPerPixel() / 8;
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        _filter.SetPixelColor(ptr);
                    }

                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
