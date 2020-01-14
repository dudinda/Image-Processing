﻿using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class UniformDistribution : IDistribution
    {
        private decimal _a;
        private decimal _b;

        public UniformDistribution() { }
        public UniformDistribution(decimal a, decimal b)
        {
            _a = a;
            _b = b;
        }

        public decimal FirstParameter => _a;
        public decimal SecondParameter => _b;

        public decimal GetMean() => (_a + _b) / 2;
        public decimal GetVariance() => (_b - _a) * (_b - _a) / 12;
        public decimal Quantile(decimal p) => _a + p * (_b - _a);

        public void SetParams((decimal, decimal) parms)
        {
            _a = parms.Item1;
            _b = parms.Item2;
        }
    }
}
