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
        public decimal Quantile(decimal p) {

            if (p >= 1) return 0;
     
            return -DecimalMathReal.Log(1 - p) / _lambda;
        }

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _lambda = parms.Item1;
            return this;
        }
    }
}
