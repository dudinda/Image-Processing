using System;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Extensions.StringExtensions;
using ImageProcessing.Utility.DecimalMath.Real;
using ImageProcessing.App.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.App.DomainModel.Model.Distributions.Implementation.OneParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
    internal sealed class ParabolaDistribution : IDistribution
    {
        private decimal _k;

        public ParabolaDistribution()
        {

        }

        public ParabolaDistribution(decimal k)
        {
            _k = k;
        }

        /// <inheritdoc/>
        public string Name => nameof(Distribution.Parabola);

        /// <inheritdoc/>
        public decimal FirstParameter => _k;

        /// <inheritdoc/>
        public decimal SecondParameter => throw new NotSupportedException();

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1)
            {
                quantile = _k * (1M - DecimalMathReal.Pow(1M - p, 0.3M));

                return true;
            }

            quantile = 0;

            return false;
        }

        /// <inheritdoc/>
        public decimal GetMean()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public decimal GetVariance()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IDistribution SetParams((string First, string Second) parms)
        {
            if(!parms.First.TryParse(out _k))
            {
                throw new ArgumentException(nameof(parms.First));
            }

            return this;
        }
    }
}
