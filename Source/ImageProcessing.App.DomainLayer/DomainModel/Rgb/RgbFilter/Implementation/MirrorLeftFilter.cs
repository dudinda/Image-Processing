using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    public sealed class MirrorLeftFilter : IRgbFilter
    {
        /// <inheritdoc />
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

            var height = src.Height;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            var stride = bitmapData.Stride;
            var endStride = stride - step;

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
                        end[3] = start[3];

                        start += step;
                        end -= step;

                    } while (start < end);
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }
    }
}
