using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class WeibullDistribution : IDistribution
    {
        public double FirstParameter { get { return _lambda; } }
        public double SecondParameter { get { return _k; } }

        private double _lambda;
        private double _k;

        public WeibullDistribution()
        {

        }

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

        public void SetParams((double, double) parms)
        {
            _lambda = parms.Item1;
            _k      = parms.Item2;
        }
    }
}
