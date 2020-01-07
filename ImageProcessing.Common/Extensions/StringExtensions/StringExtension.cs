using System.ComponentModel;
using System.Drawing.Imaging;

namespace ImageProcessing.Common.Extensions.StringExtensions
{
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
            }

            return ImageFormat.Wmf;
        }

        public static bool TryParse<T>(this string input, out T value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFromString(input);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
    }
}
