using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Code.Extensions.StringExt;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.Utility.DecimalMath.Real;
using ImageProcessing.Utility.DecimalMath.SpecialFunctions;

namespace ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.TwoParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
    internal sealed class WeibullDistribution : IDistribution
    {
        private static readonly DecimalSpecial _special = new DecimalSpecial();
        private static readonly DecimalReal _real = new DecimalReal();

        private decimal _lambda;
        private decimal _k;

        public WeibullDistribution()
        {

        }

        public WeibullDistribution(decimal lambda, decimal k)
        {
            _lambda = lambda;
            _k = k;
        }

        /// <inheritdoc/>
        public string Name => nameof(PrDistribution.Weibull);

        /// <inheritdoc/>
        public decimal FirstParameter => _lambda;

        /// <inheritdoc/>
        public decimal SecondParameter => _k;

        /// <inheritdoc/>
        public decimal GetMean()
            => _lambda * _special.Gamma((1 / _k, 0)).Re;

        /// <inheritdoc/>
        public decimal GetVariance()
            => _lambda * _lambda *
            _special.Gamma((2 / _k, 0)).Re - GetMean() * GetMean();

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1 && _k != 0)
            {
                quantile = _lambda * _real.Pow(-_real.Log(1 - p), 1.0M / _k);

                return true;
            }

            quantile = 0;

            return false;
        }

        /// <inheritdoc/>
        public IDistribution SetParams((string First, string Second) parms)
        {
            if (!parms.First.TryParse(out _lambda))
            {
                throw new ArgumentException(nameof(parms.First));
            }

            if (!parms.Second.TryParse(out _k))
            {
                throw new ArgumentException(nameof(parms.Second));
            }

            return this;
        }
    }
}
