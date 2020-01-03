using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Extensions.BitmapExtensions
{
    public static class BitmapExtension
    {
        public static Bitmap Shuffle(this Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            var resolution = bitmap.Width * bitmap.Height;

            var random = new Random();

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                byte R, G, B;

                var ptr = startPtr;

                for (var index = resolution - 1; index > 1; --index, ptr += 3)
                {
                    var newPtr = startPtr + random.Next(index) * 3;

                    B = ptr[0];
                    G = ptr[1];
                    R = ptr[2];

                    ptr[0] = newPtr[0];
                    ptr[1] = newPtr[1];
                    ptr[2] = newPtr[2];

                    newPtr[0] = B;
                    newPtr[1] = G;
                    newPtr[2] = R;

                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

    }
}
