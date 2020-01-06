using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    class ParabolaDistribution : IDistribution
    {
        private double _k;

        public ParabolaDistribution()
        {

        }

        public ParabolaDistribution(double k)
        {
            _k = k;
        }

        public double FirstParameter { get { return _k; } }
        public double SecondParameter => throw new NotImplementedException();

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

        public void SetParams((double, double) parms)
        {
            _k = parms.Item1;
        }
    }
}
