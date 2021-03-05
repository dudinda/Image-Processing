using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation
{
    /// <summary>
    /// Implements the <see cref="IRgbFilter"/>.
    /// </summary>
    internal sealed class InversionFilter : IRgbFilter
    {
        private static readonly ConcurrentDictionary<RgbFltr, byte[]>
            _inverseCache = new ConcurrentDictionary<RgbFltr, byte[]>();

        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap)
        {
            var inverse = GetReversedByteOrder();
            var (width, height) = (bitmap.Width, bitmap.Height);

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

                Parallel.For(0, height, options, y =>
                {
                    //get the address of a row
                    var ptr = startPtr + y * bitmapData.Stride;
                    for (int x = 0; x < width; ++x, ptr += ptrStep)
                    {
                        ptr[0] = inverse[ptr[0]];
                        ptr[1] = inverse[ptr[1]];
                        ptr[2] = inverse[ptr[2]];
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        private byte[] GetReversedByteOrder()
        {
            if (_inverseCache.TryGetValue(RgbFltr.Inversion, out var bytes))
            {
                return bytes;
            }

            var result = new byte[256];

            for (var index = 0; index < 256; ++index)
            {
                result[index] = (byte)(255 - index);
            }

            if (_inverseCache.TryAdd(RgbFltr.Inversion, result))
            {
                return result;
            }

            throw new InvalidOperationException(nameof(_inverseCache));
        }
    }
}
