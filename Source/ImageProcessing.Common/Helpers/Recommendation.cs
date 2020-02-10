using System;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Common.Helpers
{
    public static class Recommendation
    {

        public static double GetLumaCoefficients(this (byte R, byte G, byte B) pixel, Luma rec)
            => GetLumaCoefficients(((double)pixel.R, (double)pixel.B, (double)pixel.G), rec);

        /// <summary>
        /// Evaluate relative luminance using a specified recommendation
        /// </summary>
        /// <param name="pixel">The source pixel</param>
        /// <param name="rec">The specified recommendation</param>
        /// <returns>Relative luminance value as <see cref="double"></returns>
        public static double GetLumaCoefficients((double R, double G, double B) pixel, Luma rec)
        {
            switch(rec)
            {
                case Luma.Rec601:
                    return GetRec601(pixel);
                case Luma.Rec709:
                    return GetRec709(pixel);
                case Luma.Rec240:
                    return GetRec240(pixel);

                default: throw new InvalidOperationException(nameof(rec));
            }
        }

        /// <summary>
        /// Evaluate relative luminance by Rec. 601
        /// </summary>
        private static double GetRec601((double R, double B, double G) pixel) 
            => pixel.R * 0.299 + pixel.B * 0.587 + pixel.G * 0.114;

        /// <summary>
        /// Evaluate relative luminance by Rec. 709
        /// </summary>
        private static double GetRec709((double R, double B, double G) pixel)
           => pixel.R * 0.2126 + pixel.B * 0.7152 + pixel.G * 0.0722;

        /// <summary>
        /// Evaluate relative luminance by Rec. 240
        /// </summary>
        private static double GetRec240((double R, double B, double G) pixel)
           => pixel.R * 0.212 + pixel.B * 0.701 + pixel.G * 0.087;
    }
}
