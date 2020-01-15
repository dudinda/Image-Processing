using System;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    public class RayleighDistribution : IDistribution
    {
        private decimal _sigma;

        public decimal FirstParameter => _sigma;
        public decimal SecondParameter => throw new NotImplementedException();

        public decimal GetMean() => _sigma * DecimalMath.Sqrt(DecimalMath.PI / 2M);
        public decimal GetVariance() => (2M - DecimalMath.PI / 2M) * _sigma * _sigma;
        public decimal Quantile(decimal p)
        {
            if(p >= 1) return 0;

            return _sigma * DecimalMath.Sqrt(-2M * DecimalMath.Log(1M - p));
        }

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _sigma = parms.Item1;
            return this;
        }
    }
}
