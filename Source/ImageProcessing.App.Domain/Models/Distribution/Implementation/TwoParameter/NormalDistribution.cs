using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Code.Extensions;
using ImageProcessing.App.Domain.Services.DecimalMath.Real;
using ImageProcessing.App.Domain.Services.DecimalMath.Special;

namespace ImageProcessing.App.Domain.Models.Distribution.Implementation.TwoParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
    public sealed class NormalDistribution : IDistribution
    {
        private readonly DecimalSpecial _special = new();
        private readonly DecimalReal _real = new();
        
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
        public string Name => nameof(PrDistribution.Normal);

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

            if (_real.Abs(erfArg) < 1)
            {
                quantile = _mu + _sigma * DecimalReal.Sqrt2 * _special.ErfInv(2 * p - 1);

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
