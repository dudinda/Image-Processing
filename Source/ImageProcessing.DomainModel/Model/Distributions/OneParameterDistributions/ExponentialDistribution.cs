using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Distributions.OneParameterDistributions
{
    /// <inheritdoc/>
    public class ExponentialDistribution : IDistribution
    {
        private decimal _lambda;

        public ExponentialDistribution()
        {

        }

        public ExponentialDistribution(decimal lambda)
        {
            _lambda = lambda;
        }

        /// <inheritdoc/>
        public string Name => nameof(Distribution.Exponential);

        /// <inheritdoc/>
        public decimal FirstParameter => _lambda;

        /// <inheritdoc/>
        public decimal SecondParameter => throw new NotSupportedException();

        /// <inheritdoc/>
        public decimal GetMean() => 1 / _lambda;

        /// <inheritdoc/>
        public decimal GetVariance() => 1 / (_lambda * _lambda);

        /// <inheritdoc/>
        public bool Quantile(decimal p, out decimal quantile)
        {
            if (p < 1)
            {
                quantile = -DecimalMathReal.Log(1 - p) / _lambda;

                return true;
            }

            quantile = 0;

            return false;
        }

        /// <inheritdoc/>
        public IDistribution SetParams((string First, string Second) parms)
        {
            if(!parms.First.TryParse(out _lambda))
            {
                throw new ArgumentException(nameof(parms.First));
            }

            return this;
        }
    }
}
