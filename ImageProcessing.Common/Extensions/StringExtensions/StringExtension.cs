using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Extensions.StringExtensions
{
    public static class StringExtension
    {
        public static ImageFormat GetImageFormat(this string ext)
        {
            if (ext.Equals(".jpeg")) return ImageFormat.Jpeg;
            if (ext.Equals(".bmp")) return ImageFormat.Bmp;
            if (ext.Equals(".png")) return ImageFormat.Png;
            if (ext.Equals(".emf")) return ImageFormat.Emf;
            if (ext.Equals(".exif")) return ImageFormat.Exif;
            if (ext.Equals(".gif")) return ImageFormat.Gif;
            if (ext.Equals(".icon")) return ImageFormat.Icon;
            if (ext.Equals(".memorybmp")) return ImageFormat.MemoryBmp;
            if (ext.Equals(".tiff")) return ImageFormat.Tiff;

            else return ImageFormat.Wmf;

        }
    }
}
