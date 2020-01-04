using System;

using ImageProcessing.Distributions.Abstract;

using MathNet.Numerics;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class NormalDistribution : IDistribution
    {

        private readonly double _mu;
        private readonly double _sigma;

        public NormalDistribution(double mu, double sigma)
        {
            _mu    = mu;
            _sigma = sigma;
        }

        public string Name { get; } = "Normal Distribution";
        public double GetMean() => _mu;
        public double GetVariance() => _sigma * _sigma;
        public double Quantile(double p) => _mu + _sigma * Math.Sqrt(2) * SpecialFunctions.ErfInv(2 * p - 1);           
    }
}
