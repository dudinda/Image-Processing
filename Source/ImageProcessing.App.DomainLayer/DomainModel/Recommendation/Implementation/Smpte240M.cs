using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Implementation
{
    /// <inheritdoc cref="IRecommendation"/>
    public sealed class Smpte240M : IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance by SMPTE 240M.
        /// </summary>
        public double GetLuma(ref byte r, ref byte g, ref byte b)
            => r * 0.212 + g * 0.701 + b * 0.087;
    }
}
