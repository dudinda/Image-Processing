using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.DomainModel.Thresholding.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Thresholding.Implementation
{
    public sealed class GrayscaleThreshold : IThreshold
    {
        public Bitmap Segment(Bitmap src, byte threshold)
        {
            if (src is null) { throw new ArgumentNullException(nameof(src)); }
            if (src.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            var bitmapData = src.LockBits(
                new Rectangle(0, 0, src.Width, src.Height),
                ImageLockMode.ReadWrite, src.PixelFormat);

            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;

            var size = src.Size;
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += step)
                    {
                        //if a threshold value is greater or equal than a pixel value
                        //set it to white; else to black
                        if (threshold >= ptr[0])
                        {
                            ptr[0] = ptr[1] = ptr[2] = 255;
                        }
                        else
                        {
                            ptr[0] = ptr[1] = ptr[2] = 0;
                        } 
                    }
                });
            }

            src.UnlockBits(bitmapData);

            return src;
        }
    }
}
