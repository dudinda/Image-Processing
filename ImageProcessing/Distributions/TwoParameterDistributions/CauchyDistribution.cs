using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class CauchyDistribution : IDistribution
    {
        private readonly double _x0;
        private readonly double _gamma;

        public CauchyDistribution(double x0, double gamma)
        {
            _x0    = x0;
            _gamma = gamma;
        }

        public string Name { get; } = "Cauchy Distribution";
        public double GetMean() => double.NaN;
        public double GetVariance() => double.PositiveInfinity;
        public double Quantile(double p) => _x0 + _gamma * Math.Tan(Math.PI * (p - 0.5));
    }
}
