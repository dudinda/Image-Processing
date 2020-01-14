using System;
using ImageProcessing.Common.Extensions.DecimalMathExtensions;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class WeibullDistribution : IDistribution
    {
        private decimal _lambda;
        private decimal _k;

        public WeibullDistribution() { }
        public WeibullDistribution(decimal lambda, decimal k)
        {
            _lambda = lambda;
            _k      = k;
        }

        public decimal FirstParameter => _lambda;
        public decimal SecondParameter => _k;

        public decimal GetMean() => throw new NotImplementedException();
        public decimal GetVariance() => throw new NotImplementedException();
        public decimal Quantile(decimal p) => _lambda * -(DecimalMath.Log(1 - p).Pow(1.0M / _k));

        public void SetParams((decimal, decimal) parms)
        {
            _lambda = parms.Item1;
            _k      = parms.Item2;
        }
    }
}
