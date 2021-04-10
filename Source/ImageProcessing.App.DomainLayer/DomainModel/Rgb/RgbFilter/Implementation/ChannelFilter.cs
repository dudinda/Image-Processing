using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    /// <summary>
    /// Implements the <see cref="IRgbFilter"/>.
    /// </summary>
    public sealed class ChannelFilter : IRgbFilter
    {
        /// <inheritdoc cref="IChannel" />
        private readonly IChannel _filter;

        public ChannelFilter(IChannel filter)
        {
            _filter = filter;
        }

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

            var (width, height) = (src.Width, src.Height);

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;
            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();
                var stride = bitmapData.Stride;

                Parallel.For(0, height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * stride;

                    for (var x = 0; x < width; ++x, ptr += step)
                    {
                        _filter.GetChannel(ptr);
                    }
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }
    }
}
