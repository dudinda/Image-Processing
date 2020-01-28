using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class LaplaceDistribution : IDistribution
    {
        private decimal _mu;
        private decimal _b;

        public string Name => nameof(Distribution.Laplace);
        public decimal FirstParameter => _mu;
        public decimal SecondParameter => _b;

        public decimal GetMean() => _mu;
        public decimal GetVariance() => 2 * _b * _b;
        public decimal Quantile(decimal p)
            => _mu + _b *
            DecimalMathReal.Sign(p - 0.5M) *
            DecimalMathReal.Log(1 - 2 * DecimalMathReal.Abs(p - 0.5M));

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _mu = parms.Item1;
            _b  = parms.Item2;
            return this;
        }
    }
}
