using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Code.Extensions.StringExt;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.Utility.DecimalMath.Real;

namespace ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.TwoParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
    internal sealed class LaplaceDistribution : IDistribution
    {
        private static readonly DecimalReal _math = new DecimalReal();

        private decimal _mu;
        private decimal _b;

        public LaplaceDistribution()
        {

        }

        public LaplaceDistribution(decimal mu, decimal b)
        {
            _mu = mu;
            _b = b;
        }

        /// <inheritdoc/>
        public string Name => nameof(PrDistribution.Laplace);

        /// <inheritdoc/>
        public decimal FirstParameter => _mu;

        /// <inheritdoc/>
        public decimal SecondParameter => _b;

        /// <inheritdoc/>
        public decimal GetMean() => _mu;

        /// <inheritdoc/>
        public decimal GetVariance() => 2 * _b * _b;

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if(p > 0 && p < 1)
            {
                quantile = _mu +  _b * _math.Sign(p - 0.5M) * _math.Log(1 - 2 * _math.Abs(p - 0.5M));

                return true;
            }

            quantile = 0;

            return false;
        }

        /// <inheritdoc/>
        public IDistribution SetParams((string First, string Second) parms)
        {
            if(!parms.First.TryParse(out _mu))
            {
                throw new ArgumentException(nameof(parms.First));
            }

            if(!parms.Second.TryParse(out _b))
            {
                throw new ArgumentException(nameof(parms.Second));
            }

            return this;
        }
    }
}
