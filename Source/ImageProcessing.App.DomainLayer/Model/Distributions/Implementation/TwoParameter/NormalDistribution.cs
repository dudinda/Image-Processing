using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.StringExt;
using ImageProcessing.App.DomainLayer.Model.Distributions.Interface;
using ImageProcessing.Utility.DecimalMath.RealAxis;
using ImageProcessing.Utility.DecimalMath.SpecialFunctions;

namespace ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.TwoParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
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
        public string Name => nameof(CommonLayer.Enums.Distributions.Normal);

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
            var erfArg = 2 * p - 1;

            if (DecimalMathReal.Abs(erfArg) < 1)
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
