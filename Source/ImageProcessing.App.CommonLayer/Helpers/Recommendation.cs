using System;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.CommonLayer.Helpers
{
    public static class Recommendation
    {
        public static double GetLumaCoefficients(ref byte R, ref byte G, ref byte B, ref Luma rec)
            => GetLumaCoefficientsByRec(R, G, B, ref rec);

        /// <summary>
        /// Evaluate relative luminance using a specified recommendation.
        /// </summary>
        /// <param name="pixel">The source pixel</param>
        /// <param name="rec">The specified recommendation</param>
        /// <returns>Relative luminance value as <see cref="double"></returns>
        public static double GetLumaCoefficientsByRec(double R, double G, double B, ref Luma rec)
        {
            switch(rec)
            {
                case Luma.Rec601:
                    return GetRec601(ref R, ref G, ref B);
                case Luma.Rec709:
                    return GetRec709(ref R, ref G, ref B);
                case Luma.Rec240:
                    return GetSmpte240M(ref R, ref G, ref B);

                default: throw new InvalidOperationException(nameof(rec));
            }
        }

        /// <summary>
        /// Evaluate relative luminance by Rec. 601.
        /// </summary>
        private static double GetRec601(ref double R, ref double G, ref double B) 
            => R * 0.299 + G * 0.587 + B * 0.114;

        /// <summary>
        /// Evaluate relative luminance by Rec. 709.
        /// </summary>
        private static double GetRec709(ref double R, ref double G, ref double B)
           => R * 0.2126 + G * 0.7152 + B * 0.0722;

        /// <summary>
        /// Evaluate relative luminance by SMPTE 240M.
        /// </summary>
        private static double GetSmpte240M(ref double R, ref double G, ref double B)
           => R * 0.212 + G * 0.701 + B * 0.087;
    }
}
