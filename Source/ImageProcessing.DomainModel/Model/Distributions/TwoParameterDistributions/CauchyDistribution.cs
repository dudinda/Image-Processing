using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    public class CauchyDistribution : IDistribution
    {
        private double _x0;
        private double _gamma;

        public CauchyDistribution() { }
        public CauchyDistribution(double x0, double gamma)
        {
            _x0    = x0;
            _gamma = gamma;
        }

        public double FirstParameter => _x0;
        public double SecondParameter => _gamma;

        public double GetMean() => double.NaN;
        public double GetVariance() => double.PositiveInfinity;
        public double Quantile(double p) => _x0 + _gamma * Math.Tan(Math.PI * (p - 0.5));

        public void SetParams((double, double) parms)
        {
            _x0    = parms.Item1;
            _gamma = parms.Item2;
        }
    }
}
