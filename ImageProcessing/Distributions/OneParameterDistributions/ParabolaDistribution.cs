using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    class ParabolaDistribution : IDistribution
    {
        private readonly double _k;

        public ParabolaDistribution(double k)
        {
            _k = k;
        }

        public string Name { get; } = "Parabola distribution";
        public double Quantile(double p)
        {
            return _k * (1 - Math.Pow(1 - p, 0.3));
        }
        public double GetMean()
        {
            throw new NotImplementedException();
        }
        public double GetVariance()
        {
            throw new NotImplementedException();
        }
    }
}
