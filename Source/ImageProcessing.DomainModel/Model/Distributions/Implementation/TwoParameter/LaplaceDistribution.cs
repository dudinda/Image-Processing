using System;
using System.Runtime.CompilerServices;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.DecimalMath.Real;
using ImageProcessing.DomainModel.Model.Distributions.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.DomainModel.Model.Distributions.Implementation.TwoParameter
{
    /// <summary>
    /// Implements <see cref="IDistribution"/>
    /// </summary>
    internal sealed class LaplaceDistribution : IDistribution
    {
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
        public string Name => nameof(Distribution.Laplace);

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
                quantile = _mu +  _b * DecimalMathReal.Sign(p - 0.5M) * DecimalMathReal.Log(1 - 2 * DecimalMathReal.Abs(p - 0.5M));

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
