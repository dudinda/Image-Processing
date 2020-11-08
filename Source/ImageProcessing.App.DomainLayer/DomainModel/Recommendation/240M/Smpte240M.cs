using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Implementation
{
    /// <inheritdoc cref="Rec"/>
    internal sealed class Smpte240M : Rec
    {
        /// <summary>
        /// Evaluate relative luminance by SMPTE 240M.
        /// </summary>
        public override double GetLuma(ref byte r, ref byte g, ref byte b)
            => r * 0.212 + g * 0.701 + b * 0.087;
    }
}
