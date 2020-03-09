using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class CauchyDistribution : IDistribution
    {
        private decimal _x0;
        private decimal _gamma;

        public string Name => nameof(Distribution.Cauchy);
        public decimal FirstParameter => _x0;
        public decimal SecondParameter => _gamma;
        public decimal GetMean() => throw new NotImplementedException("NaN");
        public decimal GetVariance() => throw new ArithmeticException("NaN");
        public bool Quantile(decimal p, out decimal quantile)
        {
            if(p > 0 && p < 1)
            {
                quantile = _x0 + _gamma * DecimalMathReal.Tan(DecimalMathReal.PI * (p - 0.5M));

                return true;
            }

            quantile = 0;

            return false;
        }
       
        public IDistribution SetParams((decimal, decimal) parms)
        {
            _x0    = parms.Item1;
            _gamma = parms.Item2;
            return this;
        }
    }
}
