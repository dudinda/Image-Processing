using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    public class RayleighDistribution : IDistribution
    {
        private decimal _sigma;

        public string Name => nameof(Distribution.Rayleigh);
        public decimal FirstParameter => _sigma;
        public decimal SecondParameter => throw new NotImplementedException();

        public decimal GetMean() => _sigma * DecimalMathReal.Sqrt(DecimalMathReal.PI / 2M);
        public decimal GetVariance() => (2M - DecimalMathReal.PI / 2M) * _sigma * _sigma;

        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p >= 0 && p < 1)
            {
                quantile = _sigma * DecimalMathReal.Sqrt(-2M * DecimalMathReal.Log(1M - p));
                return true;
            }

            quantile = 0;

            return false;
        }

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _sigma = parms.Item1;
            return this;
        }
    }
}
