using System;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class LaplaceDistribution : IDistribution
    {
        private decimal _mu;
        private decimal _b;

        public LaplaceDistribution() { }
        public LaplaceDistribution(decimal mu, decimal b)
        {
            _mu = mu;
            _b  = b;
        }

        public decimal FirstParameter => _mu;
        public decimal SecondParameter => _b;

        public decimal GetMean() => _mu;
        public decimal GetVariance() => 2 * _b * _b;
        public decimal Quantile(decimal p) 
            => _mu + _b * 
            DecimalMath.Sign(p - 0.5M) *
            DecimalMath.Log(1 - 2 * DecimalMath.Abs(p - 0.5M));

        public void SetParams((decimal, decimal) parms)
        {
            _mu = parms.Item1;
            _b  = parms.Item2;
        }
    }
}
