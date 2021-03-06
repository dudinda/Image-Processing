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
    public sealed class CauchyDistribution : IDistribution
    {
        private readonly DecimalReal _math = new DecimalReal();

        private decimal _x0;
        private decimal _gamma;

        public CauchyDistribution()
        {

        }

        public CauchyDistribution(decimal x0, decimal gamma)
        {
            _x0    = x0;
            _gamma = gamma;
        }

        /// <inheritdoc/>
        public string Name => nameof(PrDistribution.Cauchy);

        /// <inheritdoc/>
        public decimal FirstParameter => _x0;

        /// <inheritdoc/>
        public decimal SecondParameter => _gamma;

        /// <inheritdoc/>
        public decimal GetMean() => throw new ArithmeticException("NaN");

        /// <inheritdoc/>
        public decimal GetVariance() => throw new ArithmeticException("NaN");

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if(p > 0 && p < 1)
            {
                quantile = _x0 + _gamma * _math.Tan(DecimalReal.PI * (p - 0.5M));

                return true;
            }

            quantile = 0;

            return false;
        }

        /// <inheritdoc/>
        public IDistribution SetParams((string First, string Second) parms)
        {
            if (!parms.First.TryParse(out _x0))
            {
                throw new ArgumentException(nameof(parms.First));
            }

            if (!parms.Second.TryParse(out _gamma))
            {
                throw new ArgumentException(nameof(parms.Second));
            }

            return this;
        }
    }
}
