using System;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

using MathNet.Numerics;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class NormalDistribution : IDistribution
    {
        private decimal _mu;
        private decimal _sigma;

        public decimal FirstParameter => _mu;
        public decimal SecondParameter => _sigma;

        public decimal GetMean() => _mu;
        public decimal GetVariance() => _sigma * _sigma;
        public decimal Quantile(decimal p) => 
            _mu + _sigma * DecimalMath.Sqrt(2) * 
            (decimal)SpecialFunctions.ErfInv(Convert.ToDouble(2 * p - 1));

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _mu    = parms.Item1;
            _sigma = parms.Item2;
            return this;
        }
    }
}
