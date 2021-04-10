using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    public sealed class SepiaToneFilter : IRgbFilter
    {
        public Bitmap Filter(Bitmap src)
        {
            if (src is null) { throw new ArgumentNullException(nameof(src)); }
            if (src.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            var bitmapData = src.LockBits(
                new Rectangle(0, 0, src.Width, src.Height),
                ImageLockMode.ReadWrite, src.PixelFormat);

            var (width, height) = (src.Width, src.Height);
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var stride = bitmapData.Stride;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * stride;

                    double r, g, b;

                    for (var x = 0; x < width; ++x, ptr += step)
                    {
                        r = ptr[2] * 0.393 + ptr[1] * 0.769 + ptr[0] * 0.189;
                        g = ptr[2] * 0.349 + ptr[1] * 0.686 + ptr[0] * 0.168;
                        b = ptr[2] * 0.272 + ptr[1] * 0.534 + ptr[0] * 0.131;

                        if (b > 255d) { b = 255d; }
                        if (g > 255d) { g = 255d; } 
                        if (r > 255d) { r = 255d; }

                        ptr[2] = (byte)r; ptr[1] = (byte)g; ptr[0] = (byte)b;
                    }
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }
    }
}
