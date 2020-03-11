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

        public WeibullDistribution()
        {

        }

        public WeibullDistribution(decimal lambda, decimal k)
        {
            _lambda = lambda;
            _k      = k;
        }

        public string Name => nameof(Distribution.Weibull);

        public decimal FirstParameter => _lambda;

        public decimal SecondParameter => _k;

        public decimal GetMean() => throw new NotImplementedException();

        public decimal GetVariance() => throw new NotImplementedException();

        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1)
            {
                quantile = _lambda * -(DecimalMathReal.Log(1 - p).Pow(1.0M / _k));

                return true;
            }

            quantile = 0;

            return false;
        } 

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _lambda = parms.Item1;
            _k      = parms.Item2;

            return this;
        }
    }
}
