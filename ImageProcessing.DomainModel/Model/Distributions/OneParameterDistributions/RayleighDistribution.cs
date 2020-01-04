using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    class RayleighDistribution : IDistribution
    {
        private readonly double _sigma;
        public RayleighDistribution(double sigma)
        {
            _sigma = sigma;
        }
        public string Name { get; } = "Rayleigh Distribution";
        public double GetMean() => _sigma * Math.Sqrt(Math.PI / 2);
        public double GetVariance() => (2 - Math.PI / 2) * _sigma * _sigma;
        public double Quantile(double p)
        {
            if(p >= 1)
            {
                return 0;
            }

            return _sigma * Math.Sqrt(-2 * Math.Log(1 - p));
        }
    }
}
