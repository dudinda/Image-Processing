namespace ImageProcessing.App.DomainLayer.Model.Recommendation.Interface
{
    public interface IRecommendation
    {
        /// <summary>
        /// Evaluate relative luminance.
        /// </summary>
        double GetLuma(ref byte R, ref byte G, ref byte B);
    }
}
