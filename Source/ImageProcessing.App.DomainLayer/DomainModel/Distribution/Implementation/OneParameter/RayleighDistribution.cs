using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Code.Extensions.StringExt;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.Utility.DecimalMath.Real;

namespace ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.OneParameter
{
    /// <summary>
    /// Implements the <see cref="IDistribution"/>.
    /// </summary>
    internal sealed class RayleighDistribution : IDistribution
    {
        private static readonly DecimalReal _math = new DecimalReal();

        private decimal _sigma;

        public RayleighDistribution()
        {

        }

        public RayleighDistribution(decimal sigma)
        {
            _sigma = sigma;
        }

        /// <inheritdoc/>
        public string Name => nameof(PrDistribution.Rayleigh);

        /// <inheritdoc/>
        public decimal FirstParameter => _sigma;

        /// <inheritdoc/>
        public decimal SecondParameter => throw new NotSupportedException();

        /// <inheritdoc/>
        public decimal GetMean() => _sigma * (decimal)Math.Sqrt((double)DecimalReal.PiOver2);

        /// <inheritdoc/>
        public decimal GetVariance() => (2M - DecimalReal.PiOver2) * _sigma * _sigma;

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p >= 0 && p < 1)
            {
                quantile = _sigma * (decimal)Math.Sqrt((double)(-2M * _math.Log(1M - p)));
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
