using System;
using ImageProcessing.Common.Utility.DecimalMath;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class CauchyDistribution : IDistribution
    {
        private decimal _x0;
        private decimal _gamma;

        public CauchyDistribution() { }
        public CauchyDistribution(decimal x0, decimal gamma)
        {
            _x0    = x0;
            _gamma = gamma;
        }

        public decimal FirstParameter => _x0;
        public decimal SecondParameter => _gamma;
        public decimal GetMean() => throw new NotImplementedException();
        public decimal GetVariance() => throw new ArithmeticException("+inf");
        public decimal Quantile(decimal p) => _x0 + _gamma * DecimalMath.Tan(DecimalMath.PI * (p - 0.5M));

        public void SetParams((decimal, decimal) parms)
        {
            _x0    = parms.Item1;
            _gamma = parms.Item2;
        }
    }
}
