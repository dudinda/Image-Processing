using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class LaplaceDistribution : IDistribution
    {
        private readonly double _mu;
        private readonly double _b;

        public LaplaceDistribution(double mu, double b)
        {
            _mu = mu;
            _b  = b;
        }

        public string Name { get; } = "Laplace Distribution";
        public double GetMean() => _mu;
        public double GetVariance() => 2 * _b * _b;
        public double Quantile(double p) => _mu + _b * Math.Sign(p - 0.5) * Math.Log(1 - 2 * Math.Abs(p - 0.5));
    }
}
