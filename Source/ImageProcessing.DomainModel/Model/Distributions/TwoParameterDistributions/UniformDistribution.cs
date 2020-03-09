using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class UniformDistribution : IDistribution
    {
        private decimal _a;
        private decimal _b;

        public string Name => nameof(Distribution.Uniform);
        public decimal FirstParameter => _a;
        public decimal SecondParameter => _b;

        public decimal GetMean() => (_a + _b) / 2;
        public decimal GetVariance() => (_b - _a) * (_b - _a) / 12;
        public bool Quantile(decimal p, out decimal quantile)
        {
            quantile = _a + p * (_b - _a);

            return true;
        }
        

        public IDistribution SetParams((decimal, decimal) parms)
        {
            _a = parms.Item1;
            _b = parms.Item2;
            return this;
        }
    }
}
