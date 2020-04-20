using ImageProcessing.App.DomainLayer.Model.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.Model.Recommendation.Implementation
{
    internal sealed class Rec709 : IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance by Rec. 709.
        /// </summary>
        public double GetLuma(ref byte R, ref byte G, ref byte B)
            => R * 0.2126 + G * 0.7152 + B * 0.0722;
    }
}
