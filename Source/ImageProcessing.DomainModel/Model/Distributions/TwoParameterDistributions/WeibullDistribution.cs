using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.DecimalMathRealExtensions;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class WeibullDistribution : IDistribution
    {
        private decimal _lambda;
        private decimal _k;

        public string Name => nameof(Distribution.Weibull);
        public decimal FirstParameter => _lambda;
        public decimal SecondParameter => _k;

        public decimal GetMean() => throw new NotImplementedException();
        public decimal GetVariance() => throw new NotImplementedException();
        public decimal Quantile(decimal p) => _lambda * -(DecimalMathReal.Log(1 - p).Pow(1.0M / _k));

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _lambda = parms.Item1;
            _k      = parms.Item2;
            return this;
        }
    }
}
