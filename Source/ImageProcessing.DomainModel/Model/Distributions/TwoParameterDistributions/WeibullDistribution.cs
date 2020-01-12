using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class WeibullDistribution : IDistribution
    {
        private double _lambda;
        private double _k;

        public WeibullDistribution() { }
        public WeibullDistribution(double lambda, double k)
        {
            _lambda = lambda;
            _k      = k;
        }

        public double FirstParameter => _lambda;
        public double SecondParameter => _k;

        public double GetMean() => throw new NotImplementedException();
        public double GetVariance() => throw new NotImplementedException();
        public double Quantile(double p) => _lambda * Math.Pow(-Math.Log(1 - p), 1.0 / _k);

        public void SetParams((double, double) parms)
        {
            _lambda = parms.Item1;
            _k      = parms.Item2;
        }
    }
}
