using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    internal sealed class MirrorLeftFilter : IRgbFilter
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var ptrStep = bitmap.GetBitsPerPixel() / 8;

            var (width, height) = (bitmap.Width, bitmap.Height);
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var stride = bitmapData.Stride;
            var endStride = stride - ptrStep;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();
                
                Parallel.For(0, height, options, y =>
                {
                    //get the address of a row
                    var start = startPtr + y * stride;
                    var end = start + endStride;

                    do
                    {
                        end[0] = start[0];
                        end[1] = start[1];
                        end[2] = start[2];

                        start += ptrStep;
                        end -= ptrStep;

                    } while (start < end);
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
