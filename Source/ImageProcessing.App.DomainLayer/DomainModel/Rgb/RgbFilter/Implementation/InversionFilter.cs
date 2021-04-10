using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    /// <summary>
    /// Implements the <see cref="IRgbFilter"/>.
    /// </summary>
    public sealed class InversionFilter : IRgbFilter
    {
        private static readonly ConcurrentDictionary<RgbFltr, byte[]>
            _cache = new ConcurrentDictionary<RgbFltr, byte[]>();

        /// <inheritdoc />
        public Bitmap Filter(Bitmap src)
        {
            if (src is null) { throw new ArgumentNullException(nameof(src)); }
            if (src.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            var inverse = GetReversedByteOrder();
            var (width, height) = (src.Width, src.Height);

            var bitmapData = src.LockBits(
                new Rectangle(0, 0, src.Width, src.Height),
                ImageLockMode.ReadWrite, src.PixelFormat);

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

                    for (int x = 0; x < width; ++x, ptr += step)
                    {
                        ptr[0] = inverse[ptr[0]];
                        ptr[1] = inverse[ptr[1]];
                        ptr[2] = inverse[ptr[2]];
                    }
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }

        private static byte[] GetReversedByteOrder()
        {
            if (_cache.TryGetValue(RgbFltr.Inversion, out var bytes))
            {
                return bytes;
            }

            var result = new byte[256];

            for (var index = 0; index < 256; ++index)
            {
                result[index] = (byte)(255 - index);
            }

            if (_cache.TryAdd(RgbFltr.Inversion, result))
            {
                return result;
            }

            return result;
        }
    }
}
