namespace ImageProcessing.Distributions.Abstract
{
    public interface IDistribution
    {
        string Name     { get; }
        double GetMean();
        double GetVariance();
        double Quantile(double p);

        void SetParameters((int, int) parms);
    }
}
