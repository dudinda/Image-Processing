using ImageProcessing.App.DomainLayer.Model.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.Model.Recommendation.Implementation
{
    internal sealed class Rec601 : IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance by Rec. 601.
        /// </summary>
        public double GetLuma(ref byte R, ref byte G, ref byte B)
            => R * 0.299 + G * 0.587 + B * 0.114;
    }
}
