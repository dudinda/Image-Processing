using ImageProcessing.Enum;
using ImageProcessing.RGBFilter.Abstract;

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ImageProcessing.RGBFilter.Color
{
    public class ColorFilter : IRGBFilter
    {
        IColor _filter;
        ColorFilter(RGBColors color)
        {

        }

        public Bitmap Filter(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                         ImageLockMode.ReadWrite,
                                                         PixelFormat.Format24bppRgb);

            var size = bitmap.Size;

            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
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
