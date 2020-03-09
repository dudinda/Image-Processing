namespace ImageProcessing.Core.Model.Distribution
{
    public interface IDistribution
    {
        string Name { get; }
        decimal FirstParameter { get; }
        decimal SecondParameter { get; }
        decimal GetMean();
        decimal GetVariance();
        bool Quantile(decimal p, out decimal quanile);
        IDistribution SetParams((decimal, decimal) parms);
    }
}
