namespace ImageProcessing.Core.Model.Distribution
{
    public interface IDistribution
    {
        decimal FirstParameter { get; }
        decimal SecondParameter { get; }
        decimal GetMean();
        decimal GetVariance();
        decimal Quantile(decimal p);
        void SetParams((decimal, decimal) parms);
    }
}
