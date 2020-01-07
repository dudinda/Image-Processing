using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.RGBFilters.Grayscale
{
    public class GrayscaleFilter : IRGBFilter
    {
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
                        ptr[0] = ptr[1] = ptr[2] = (byte)(0.299 * ptr[2] +
                                                          0.587 * ptr[1] +
                                                          0.114 * ptr[0]);
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
