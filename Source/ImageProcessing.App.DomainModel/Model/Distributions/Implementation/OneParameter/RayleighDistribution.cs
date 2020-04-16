using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.StringExtensions;
using ImageProcessing.Utility.DecimalMath.Real;
using ImageProcessing.App.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.App.DomainModel.Model.Distributions.Implementation.OneParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
    internal sealed class RayleighDistribution : IDistribution
    {
        private decimal _sigma;

        public RayleighDistribution()
        {

        }

        public RayleighDistribution(decimal sigma)
        {
            _sigma = sigma;
        }

        /// <inheritdoc/>
        public string Name => nameof(Distribution.Rayleigh);

        /// <inheritdoc/>
        public decimal FirstParameter => _sigma;

        /// <inheritdoc/>
        public decimal SecondParameter => throw new NotSupportedException();

        /// <inheritdoc/>
        public decimal GetMean() => _sigma * DecimalMathReal.Sqrt(DecimalMathReal.PiOver2);

        /// <inheritdoc/>
        public decimal GetVariance() => (2M - DecimalMathReal.PiOver2) * _sigma * _sigma;

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p >= 0 && p < 1)
            {
                quantile = _sigma * DecimalMathReal.Sqrt(-2M * DecimalMathReal.Log(1M - p));
                return true;
            }

            quantile = 0;

            return false;
        }

        /// <inheritdoc/>
        public IDistribution SetParams((string First, string Second) parms)
        {
            if (!parms.First.TryParse(out _sigma))
            {
                throw new ArgumentException(nameof(parms.First));
            }
   
            return this;
        }
    }
}
