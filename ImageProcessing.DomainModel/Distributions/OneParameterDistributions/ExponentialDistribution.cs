using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    class ExponentialDistribution : IDistribution
    {
        private readonly double _lambda;
        public ExponentialDistribution(double lambda)
        {
           _lambda = lambda;
        }     
        public string Name { get; } = "Exponential Distribution";
        public double GetMean() => 1 / _lambda;
        public double GetVariance() => 1 / (_lambda * _lambda);
        public double Quantile(double p) {

            if(p >= 1)
            {
                return 0;
            }
            return -Math.Log(1 - p) / _lambda;

        }
    }
}
