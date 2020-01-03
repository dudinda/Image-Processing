using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class ParabolaDistribution : IDistribution
    {
        private double k { get; set; }

        public ParabolaDistribution(double k)
        {
            this.k = k;
        }

        public string Name { get; } = "Parabola distribution";
        public double Quantile(double p)
        {
            return k * (1 - Math.Pow(1 - p, 0.3));
        }
        public double GetMean()
        {
            throw new NotImplementedException();
        }
        public double GetVariance()
        {
            throw new NotImplementedException();
        }
    }
}
