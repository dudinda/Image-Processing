using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.StringExt;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.RealAxis;
using ImageProcessing.Utility.DecimalMath.RealAxis;

using static ImageProcessing.Utility.DecimalMath.SpecialFunctions.DecimalMathSpecial;

namespace ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.TwoParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
    internal sealed class WeibullDistribution : IDistribution
    {
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
        public string Name => nameof(Distributions.Weibull);

        /// <inheritdoc/>
        public decimal FirstParameter => _lambda;

        /// <inheritdoc/>
        public decimal SecondParameter => _k;

        /// <inheritdoc/>
        public decimal GetMean()
            => _lambda * Gamma((1 / _k, 0)).Re;

        /// <inheritdoc/>
        public decimal GetVariance()
            => _lambda * _lambda *
            Gamma((2 / _k, 0)).Re - GetMean() * GetMean();

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1 && _k != 0)
            {
                quantile = _lambda * -(DecimalMathReal.Log(1 - p).Pow(1.0M / _k));

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
