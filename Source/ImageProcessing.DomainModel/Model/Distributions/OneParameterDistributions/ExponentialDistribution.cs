using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    public class ExponentialDistribution : IDistribution
    {
        private decimal _lambda;

        public string Name => nameof(Distribution.Exponential);

        public decimal FirstParameter => _lambda;

        public decimal SecondParameter => throw new NotImplementedException();

        public decimal GetMean() => 1 / _lambda;

        public decimal GetVariance() => 1 / (_lambda * _lambda);

        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1)
            {
                quantile = -DecimalMathReal.Log(1 - p) / _lambda;

                return true;
            }

            quantile = 0;

            return false;
        }

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _lambda = parms.Item1;
            return this;
        }
    }
}
