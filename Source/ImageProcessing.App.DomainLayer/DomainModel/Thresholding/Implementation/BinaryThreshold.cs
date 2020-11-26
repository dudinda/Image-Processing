using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Thresholding.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Thresholding.Implementation
{
    internal sealed class BinaryThreshold : IThreshold
    {
        public Bitmap Segment(Bitmap bitmap, byte threshold)
        {
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            var size = bitmap.Size;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        //if a threshold value is greater or equal than a pixel value
                        //set it to white; else to black
                        if (threshold >= ptr[0]) { ptr[0] = 255; } else { ptr[0] = 0; }
                        if (threshold >= ptr[1]) { ptr[0] = 255; } else { ptr[1] = 0; }
                        if (threshold >= ptr[2]) { ptr[0] = 255; } else { ptr[2] = 0; }
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
