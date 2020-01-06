using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    class RayleighDistribution : IDistribution
    {
        private double _sigma;

        public RayleighDistribution()
        {

        }
        public RayleighDistribution(double sigma)
        {
            _sigma = sigma;
        }

        public double FirstParameter { get { return _sigma; } }
        public double SecondParameter => throw new NotImplementedException();

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

        public void SetParams((double, double) parms)
        {
            _sigma = parms.Item1;
        }
    }
}
