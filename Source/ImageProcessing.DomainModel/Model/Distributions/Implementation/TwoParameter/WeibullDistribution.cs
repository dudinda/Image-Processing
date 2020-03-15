using System;
using System.Runtime.CompilerServices;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.DecimalMathRealExtensions;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.DecimalMath.Real;
using ImageProcessing.DomainModel.Model.Distributions.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.DomainModel.Model.Distributions.Implementation.TwoParameter
{
    /// <summary>
    /// Implements <see cref="IDistribution"/>
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
            _k      = k;
        }

        /// <inheritdoc/>
        public string Name => nameof(Distribution.Weibull);

        /// <inheritdoc/>
        public decimal FirstParameter => _lambda;

        /// <inheritdoc/>
        public decimal SecondParameter => _k;

        /// <inheritdoc/>
        public decimal GetMean() => throw new NotImplementedException();

        /// <inheritdoc/>
        public decimal GetVariance() => throw new NotImplementedException();

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1)
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
