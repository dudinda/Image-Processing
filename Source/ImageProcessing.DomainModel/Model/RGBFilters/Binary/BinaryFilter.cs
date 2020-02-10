﻿using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Model.RGBFilters;

namespace ImageProcessing.RGBFilters.Binary
{
    public class BinaryFilter : IRGBFilter
    {
        public Bitmap Filter(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                             ImageLockMode.ReadWrite,
                                             bitmap.PixelFormat);

            var luminance = 0.0;
            var ptrStep = bitmap.GetBitsPerPixel() / 8;
            var size = bitmap.Size;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var bag = new ConcurrentBag<double>();

                //get N luminance partial sums
                Parallel.For<double>(0, size.Height, options, () => 0.0, (y, state, partial) =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        partial += (byte)(ptr[2], ptr[1], ptr[0]).GetLumaCoefficients(Luma.Rec709);
                    }

                    return partial;
                },
                (x) => bag.Add(x));

                //get luminance average
                var average = bag.Sum() / (size.Width * size.Height);

                Parallel.For(0, size.Height, options, y =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += ptrStep)
                    {
                        luminance = (byte)(ptr[2], ptr[1], ptr[0]).GetLumaCoefficients(Luma.Rec709);

                        //if relative luminance greater or equal than average
                        //set it to white
                        if (luminance >= average)
                        {
                            ptr[0] = ptr[1] = ptr[2] = 255;
                        }
                        //else to black
                        else
                        {
                            ptr[0] = ptr[1] = ptr[2] = 0;
                        }
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
