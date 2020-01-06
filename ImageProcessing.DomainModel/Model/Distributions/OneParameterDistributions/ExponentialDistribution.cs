using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    class ExponentialDistribution : IDistribution
    {
        private double _lambda;
        public ExponentialDistribution()
        {

        }
        public ExponentialDistribution(double lambda)
        {
           _lambda = lambda;
        }

        public double FirstParameter { get { return _lambda; } }
        public double SecondParameter => throw new NotImplementedException();

        public double GetMean() => 1 / _lambda;
        public double GetVariance() => 1 / (_lambda * _lambda);
        public double Quantile(double p) {

            if(p >= 1)
            {
                return 0;
            }
            return -Math.Log(1 - p) / _lambda;

        }

        public void SetParams((double, double) parms)
        {
            _lambda = parms.Item1;
        }
    }
}
