using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class WeibullDistribution : IDistribution
    {
        private readonly double _lambda;
        private readonly double _k;

        public WeibullDistribution(double lambda, double k)
        {
            _lambda = lambda;
            _k      = k;
        }

        public string Name { get; } = "Weibull Distribution";
        public double GetMean()
        {
            throw new NotImplementedException();
        }  
        public double GetVariance()
        {
            throw new NotImplementedException();
        }
        public double Quantile(double p) => _lambda * Math.Pow(-Math.Log(1 - p), 1.0 / _k);
   
    }
}
