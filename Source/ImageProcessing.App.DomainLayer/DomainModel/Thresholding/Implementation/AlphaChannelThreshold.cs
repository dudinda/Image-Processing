using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Thresholding.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Thresholding.Implementation
{
    internal sealed class AlphaChannelThreshold : IThreshold
    {
        public Bitmap Segment(Bitmap bitmap, byte threshold)
        {
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            if(ptrStep != 4)
            {
                throw new NotSupportedException($"{bitmap.PixelFormat} is not supported");
            }

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

                    for (var x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        if(ptr[3] > threshold)
                        {
                            ptr[3] = threshold;
                        }
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
