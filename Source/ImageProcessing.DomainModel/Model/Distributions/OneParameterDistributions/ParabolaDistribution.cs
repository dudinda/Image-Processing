using System;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    public class ParabolaDistribution : IDistribution
    {
        private decimal _k;

        public ParabolaDistribution() { }
        public ParabolaDistribution(decimal k)
        {
            _k = k;
        }

        public decimal FirstParameter => _k;
        public decimal SecondParameter => throw new NotImplementedException();

        public decimal Quantile(decimal p)
        {
            return _k * (1M - DecimalMath.Pow(1M - p, 0.3M));
        }
        public decimal GetMean()
        {
            throw new NotImplementedException();
        }
        public decimal GetVariance()
        {
            throw new NotImplementedException();
        }

        public void SetParams((decimal, decimal) parms)
        {
            _k = parms.Item1;
        }
    }
}
