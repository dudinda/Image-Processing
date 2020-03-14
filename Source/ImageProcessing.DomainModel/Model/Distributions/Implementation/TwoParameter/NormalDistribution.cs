using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.DecimalMath.Real;
using ImageProcessing.DecimalMath.Special;
using ImageProcessing.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.DomainModel.Model.Distributions.Implementation.TwoParameter
{
    /// <inheritdoc/>
    internal sealed class NormalDistribution : IDistribution
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

        /// <inheritdoc/>
        public string Name => nameof(Distribution.Normal);

        /// <inheritdoc/>
        public decimal FirstParameter => _mu;

        /// <inheritdoc/>
        public decimal SecondParameter => _sigma;

        /// <inheritdoc/>
        public decimal GetMean() => _mu;

        /// <inheritdoc/>
        public decimal GetVariance() => _sigma * _sigma;

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (DecimalMathReal.Abs(p) < 1)
            {
                quantile = _mu + _sigma * DecimalMathReal.Sqrt2 * DecimalMathSpecial.ErfInv(2 * p - 1);

                return true;
            }

            quantile = 0;

            return false;
        }

        /// <inheritdoc/>
        public IDistribution SetParams((string First, string Second) parms)
        {
            if (!parms.First.TryParse(out _mu))
            {
                throw new ArgumentException(nameof(parms.First));
            }

            if (!parms.Second.TryParse(out _sigma))
            {
                throw new ArgumentException(nameof(parms.Second));
            }

            return this;
        }
    }
}
