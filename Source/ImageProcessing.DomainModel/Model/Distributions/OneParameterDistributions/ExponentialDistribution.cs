using System;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    public class ExponentialDistribution : IDistribution
    {
        private decimal _lambda;

        public ExponentialDistribution() { }
        public ExponentialDistribution(decimal lambda)
        {
           _lambda = lambda;
        }

        public decimal FirstParameter => _lambda;
        public decimal SecondParameter => throw new NotImplementedException();

        public decimal GetMean() => 1 / _lambda;
        public decimal GetVariance() => 1 / (_lambda * _lambda);
        public decimal Quantile(decimal p) {

            if(p >= 1)
            {
                return 0;
            }
            return -DecimalMath.Log(1 - p) / _lambda;

        }

        public void SetParams((decimal, decimal) parms)
        {
            _lambda = parms.Item1;
        }
    }
}
