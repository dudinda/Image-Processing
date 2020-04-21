using ImageProcessing.App.DomainLayer.Model.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.Model.Recommendation.Implementation
{
    /// <inheritdoc cref="IRecommendation"/>
    internal sealed class Smpte240M : IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance by SMPTE 240M.
        /// </summary>
        public double GetLuma(ref byte r, ref byte g, ref byte b)
            => r * 0.212 + g * 0.701 + b * 0.087;
    }
}
