using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Implementation
{
    /// <inheritdoc cref="Rec"/>
    internal sealed class Rec709 : Rec
    {
        /// <summary>
        /// Evaluate relative luminance by Rec. 709.
        /// </summary>
        public override double GetLuma(ref byte r, ref byte g, ref byte b)
            => r * 0.2126 + g * 0.7152 + b * 0.0722;
    }
}
