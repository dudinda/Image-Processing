using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    public sealed class FlippingFilter : IRgbFilter
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

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var (width, height) = (src.Width, src.Height - 1);

            var stride = bitmapData.Stride;
            var endStride = stride * height;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();
                
                Parallel.For(0, width, options, x =>
                {
                    //get the address of a column
                    var start = startPtr + x * step;
                    var end = start + endStride;

                    byte tmp;

                    do
                    {
                        tmp = end[0];
                        end[0] = start[0];
                        start[0] = tmp;

                        tmp = end[1];
                        end[1] = start[1];
                        start[1] = tmp;

                        tmp = end[2];
                        end[2] = start[2];
                        start[2] = tmp;

                        tmp = end[3];
                        end[3] = start[3];
                        start[3] = tmp;

                        start += stride;
                        end -= stride;

                    } while (start < end);
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }
    }
}
