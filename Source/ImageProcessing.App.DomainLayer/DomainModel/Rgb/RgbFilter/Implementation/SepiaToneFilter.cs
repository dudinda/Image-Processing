using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    internal sealed class SepiaToneFilter : IRgbFilter
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
                    double r, g, b;
                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        r = ptr[2] * 0.393 + ptr[1] * 0.769 + ptr[0] * 0.189;
                        g = ptr[2] * 0.349 + ptr[1] * 0.686 + ptr[0] * 0.168;
                        b = ptr[2] * 0.272 + ptr[1] * 0.534 + ptr[0] * 0.131;

                        if (b > 255) { b = 255; }
                        if (g > 255) { g = 255; } 
                        if (r > 255) { r = 255; }

                        ptr[2] = (byte)r; ptr[1] = (byte)g; ptr[0] = (byte)b;
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
