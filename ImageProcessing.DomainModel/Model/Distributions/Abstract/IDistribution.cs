namespace ImageProcessing.Distributions.Abstract
{
    public interface IDistribution
    {
        double FirstParameter { get; }
        double SecondParameter { get; }
        double GetMean();
        double GetVariance();
        double Quantile(double p);
        void SetParams((double, double) parms);
    }
}
