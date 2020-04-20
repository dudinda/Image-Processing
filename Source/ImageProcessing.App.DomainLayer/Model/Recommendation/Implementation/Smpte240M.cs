using ImageProcessing.App.DomainLayer.Model.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.Model.Recommendation.Implementation
{
    internal sealed class Smpte240M : IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance by SMPTE 240M.
        /// </summary>
        public double GetLuma(ref byte R, ref byte G, ref byte B)
            => R * 0.212 + G * 0.701 + B * 0.087;
    }
}
