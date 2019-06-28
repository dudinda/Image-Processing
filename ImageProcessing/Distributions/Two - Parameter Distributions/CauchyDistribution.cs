using System;
using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.Two___Parameter_Distributions
{
    class CauchyDistribution : IDistribution
    {
        public CauchyDistribution(double x0, double gamma)
        {
            this.x0    = x0;
            this.gamma = gamma;
        }

        private double x0    { get; set; }
        private double gamma { get; set; }

        public string Name { get; } = "Cauchy Distribution";

        public double GetMean() => double.NaN;
   
        public double GetVariance() => double.PositiveInfinity;

        public double Quantile(double p) => x0 + gamma * Math.Tan(Math.PI * (p - 0.5));
    }
}
