using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Inversion
{
    internal sealed class InversionFilter : IRgbFilter
    {
        private static readonly ConcurrentDictionary<RgbFilter, byte[]>
            _inverseCache = new ConcurrentDictionary<RgbFilter, byte[]>();

        public Bitmap Filter(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                             ImageLockMode.ReadWrite,
                                             bitmap.PixelFormat);

            var inverse = GetReversedByteOrder();

            var size = bitmap.Size;
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
                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        ptr[0] = inverse[ptr[0]];
                        ptr[1] = inverse[ptr[1]];
                        ptr[2] = inverse[ptr[2]];
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;

            byte[] GetReversedByteOrder()
            {
                if (_inverseCache.TryGetValue(RgbFilter.Inversion, out var bytes))
                {
                    return bytes;
                }

                var result = new byte[256];

                for (var index = 0; index < 256; ++index)
                {
                    result[index] = (byte)(255 - index);
                }

                if (_inverseCache.TryAdd(RgbFilter.Inversion, result))
                {
                    return result;
                }

                throw new InvalidOperationException(nameof(_inverseCache));
            };
        }
    }
}
