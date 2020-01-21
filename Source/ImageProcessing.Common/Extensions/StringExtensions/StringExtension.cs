using System;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace ImageProcessing.Common.Extensions.StringExtensions
{
    /// <summary>
    /// Extension methods for <see cref="string"> class
    /// </summary>
    public static class StringExtension
    {
        public static ImageFormat GetImageFormat(this string ext)
        {
            switch(ext)
            {
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".png":
                    return ImageFormat.Png;
                case ".emf":
                    return ImageFormat.Emf;
                case ".exif":
                    return ImageFormat.Exif;
                case ".gif":
                    return ImageFormat.Gif;
                case ".icon":
                    return ImageFormat.Icon;
                case ".memorybmp":
                    return ImageFormat.MemoryBmp;
                case ".tiff":
                    return ImageFormat.Tiff;
                case ".wmf":
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
