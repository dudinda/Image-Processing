using System;
using System.ComponentModel;
using System.Drawing.Imaging;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;

namespace ImageProcessing.Common.Extensions.StringExtensions
{
    /// <summary>
    /// Extension methods for <see cref="string"> class
    /// </summary>
    public static class StringExtension
    {
        public static ImageFormat GetImageFormat(this string ext)
        {
            var extension = ext.GetValueFromDescription<ImageExtension>();

            switch(extension)
            {
                case ImageExtension.Jpeg:
                    return ImageFormat.Jpeg;
                case ImageExtension.Bmp:
                    return ImageFormat.Bmp;
                case ImageExtension.Png:
                    return ImageFormat.Png;
                case ImageExtension.Emf:
                    return ImageFormat.Emf;
                case ImageExtension.Exif:
                    return ImageFormat.Exif;
                case ImageExtension.Gif:
                    return ImageFormat.Gif;
                case ImageExtension.Icon:
                    return ImageFormat.Icon;
                case ImageExtension.MemoryBmp:
                    return ImageFormat.MemoryBmp;
                case ImageExtension.Tiff:
                    return ImageFormat.Tiff;
                case ImageExtension.Wmf:
                    return ImageFormat.Wmf;

                default: throw new NotImplementedException(ext);
            }
        }

        public static bool TryParse<TValue>(this string input, out TValue value)
            where TValue : struct
        {
            var converter = TypeDescriptor.GetConverter(typeof(TValue));
            try
            {
                value = (TValue)converter.ConvertFromString(input);
                return true;
            }
            catch
            {
                value = default(TValue);
                return false;
            }
        }
    }
}
