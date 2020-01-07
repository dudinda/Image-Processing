using ImageProcessing.RGBFilters.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.RGBFilters.Binary
{
    public class BinaryFilter : IRGBFilter
    {
        public Bitmap Filter(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                          ImageLockMode.ReadWrite,
                                                          PixelFormat.Format24bppRgb);

            var brightness = 0.0;

            var size = bitmap.Size;

            unsafe
            {
                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;

                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var bag = new ConcurrentBag<double>();

                //get N luminance partial sums
                Parallel.For<double>(0, size.Height, options, () => 0.0, (y, state, subtotal) =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        subtotal += 0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0];
                    }

                    return subtotal;
                },
                (x) => bag.Add(x));

                //get luminance average
                var average = bag.Sum() / (size.Width * size.Height);

                Parallel.For(0, size.Height, options, y =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        brightness = 0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0];

                        //if relative luminance greater or equal than average
                        //set it to white
                        if (brightness >= average)
                        {
                            ptr[0] = ptr[1] = ptr[2] = 255;
                        }
                        //else to black
                        else
                        {
                            ptr[0] = ptr[1] = ptr[2] = 0;
                        }
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
