using System;

using ImageProcessing.Distributions.Abstract;

using MathNet.Numerics;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class NormalDistribution : IDistribution
    {
        private double _mu;
        private double _sigma;

        public NormalDistribution()
        {

        }
        public NormalDistribution(double mu, double sigma)
        {
            _mu    = mu;
            _sigma = sigma;
        }

        public double FirstParameter => _mu;
        public double SecondParameter => _sigma;

        public double GetMean() => _mu;
        public double GetVariance() => _sigma * _sigma;
        public double Quantile(double p) => _mu + _sigma * Math.Sqrt(2) * SpecialFunctions.ErfInv(2 * p - 1);

        public void SetParams((double, double) parms)
        {
            _mu    = parms.Item1;
            _sigma = parms.Item2;
        }
    }
}
