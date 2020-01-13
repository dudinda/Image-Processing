using System;

using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class LaplaceDistribution : IDistribution
    {
        private double _mu;
        private double _b;

        public LaplaceDistribution() { }
        public LaplaceDistribution(double mu, double b)
        {
            _mu = mu;
            _b  = b;
        }

        public double FirstParameter => _mu;
        public double SecondParameter => _b;

        public double GetMean() => _mu;
        public double GetVariance() => 2 * _b * _b;
        public double Quantile(double p) => _mu + _b * Math.Sign(p - 0.5) * Math.Log(1 - 2 * Math.Abs(p - 0.5));

        public void SetParams((double, double) parms)
        {
            _mu = parms.Item1;
            _b  = parms.Item2;
        }
    }
}
