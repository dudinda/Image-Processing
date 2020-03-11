using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;
using ImageProcessing.DecimalMath.Special;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class NormalDistribution : IDistribution
    {
        private decimal _mu;
        private decimal _sigma;

        public NormalDistribution()
        {

        }

        public NormalDistribution(decimal mu, decimal sigma)
        {
            _mu = mu;
            _sigma = sigma;
        }

        public string Name => nameof(Distribution.Normal);

        public decimal FirstParameter => _mu;

        public decimal SecondParameter => _sigma;

        public decimal GetMean() => _mu;

        public decimal GetVariance() => _sigma * _sigma;

        public bool Quantile(decimal p, out decimal quantile)
        {
            if (DecimalMathReal.Abs(p) < 1)
            {
                quantile = _mu + _sigma * DecimalMathReal.Sqrt(2) * DecimalMathSpecial.ErfInv(2 * p - 1);

                return true;
            }

            quantile = 0;

            return false;
        }

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _mu    = parms.Item1;
            _sigma = parms.Item2;
            return this;
        }
    }
}
