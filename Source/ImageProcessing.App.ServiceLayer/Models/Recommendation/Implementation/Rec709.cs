using ImageProcessing.App.DomainLayer.Models.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.Models.Recommendation.Implementation
{
    /// <inheritdoc cref="IRecommendation"/>
    public sealed class Rec709 : IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance by Rec. 709.
        /// </summary>
        public double GetLuma(ref byte r, ref byte g, ref byte b)
            => r * 0.2126 + g * 0.7152 + b * 0.0722;
    }
}
