namespace ImageProcessing.App.DomainLayer.Model.Recommendation.Interface
{
    /// <summary>
    /// Forms luma (Y') using R'G'B' coefficients.
    /// </summary>
    public interface IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance.
        /// </summary>
        double GetLuma(ref byte r, ref byte g, ref byte b);
    }
}
