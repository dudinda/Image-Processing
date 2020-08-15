using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Extensions
{
    public static class BitmapExtensions
    {
        public static bool SameAs(this Bitmap bitmap, Bitmap toCompare)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                       ImageLockMode.ReadWrite,
                                                       bitmap.PixelFormat);

            var toCompareData = toCompare.LockBits(new Rectangle(0, 0, toCompare.Width, toCompare.Height),
                                                       ImageLockMode.ReadWrite,
                                                       toCompare.PixelFormat);

            if(bitmap.Width != toCompare.Width)
            {
                return false;
            }

            if(bitmap.Height != toCompare.Height)
            {
                return false;
            }

            var bitmapBits = bitmap.GetBitsPerPixel();
            var toCompareBits = toCompare.GetBitsPerPixel();

            if(bitmapBits != toCompareBits)
            {
                return false;
            }

            var resolution = bitmap.Width * bitmap.Height;
            var ptrStep = bitmap.GetBitsPerPixel() / 8;
            var size = bitmap.Size;

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var bag = new ConcurrentBag<bool>();

            unsafe
            {
                var bmpStartPtr = (byte*)bitmapData.Scan0.ToPointer();
                var toCmpStartPtr = (byte*)toCompareData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, () => true, (y, state, equal) =>
                {
                    //get the address of a row
                    var bmpPtr = bmpStartPtr + y * bitmapData.Stride;
                    var cmpPtr = toCmpStartPtr + y * toCompareData.Stride;

                    for (int x = 0; x < size.Width; ++x, bmpPtr += ptrStep, cmpPtr += ptrStep)
                    {
                        if (bmpPtr[0] != cmpPtr[0] ||
                            bmpPtr[1] != cmpPtr[1] ||
                            bmpPtr[2] != cmpPtr[2]) 
                        {
                            equal = false;
                            break;
                        }
                    }

                    return equal;
                }, (equal) => bag.Add(equal));
                
            }

            bitmap.UnlockBits(bitmapData);
            toCompare.UnlockBits(toCompareData);

            return bag.All(areEqual => areEqual);
        }
    }
}
