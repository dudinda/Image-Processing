namespace ImageProcessing.Core.Model.Distribution
{
    public interface IDistribution
    {
        decimal FirstParameter { get; }
        decimal SecondParameter { get; }
        decimal GetMean();
        decimal GetVariance();
        decimal Quantile(decimal p);
        IDistribution SetParams((decimal, decimal) parms);
    }
}
