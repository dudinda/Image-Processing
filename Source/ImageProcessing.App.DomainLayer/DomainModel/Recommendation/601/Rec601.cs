using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Implementation
{
    /// <inheritdoc cref="Rec"/>
    internal sealed class Rec601 : Rec
    {
        /// <summary>
        /// Evaluate relative luminance by Rec. 601.
        /// </summary>
        public override double GetLuma(ref byte r, ref byte g, ref byte b)
            => r * 0.299 + g * 0.587 + b * 0.114;
    }
}
