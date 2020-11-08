namespace ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface
{
    /// <summary>
    /// Forms luma (Y') using R'G'B' coefficients.
    /// </summary>
    public abstract class Rec
    {
        /// <summary>
        /// Evaluate relative luminance.
        /// </summary>
        public abstract double GetLuma(ref byte r, ref byte g, ref byte b);
    }
}
