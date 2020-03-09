using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    public class ParabolaDistribution : IDistribution
    {
        private decimal _k;

        public string Name => nameof(Distribution.Parabola);

        public decimal FirstParameter => _k;

        public decimal SecondParameter => throw new NotImplementedException();

        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1)
            {
                quantile = _k * (1M - DecimalMathReal.Pow(1M - p, 0.3M));

                return true;
            }

            quantile = 0;

            return false;
        }

        public decimal GetMean()
        {
            throw new NotImplementedException();
        }

        public decimal GetVariance()
        {
            throw new NotImplementedException();
        }

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _k = parms.Item1;
            return this;
        }
    }
}
