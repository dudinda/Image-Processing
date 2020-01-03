using System;

using ImageProcessing.Distributions.Abstract;

using MathNet.Numerics;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class NormalDistribution : IDistribution
    {

        private double mu { get; set; }
        private double sigma { get; set; }

        public NormalDistribution(double mu, double sigma)
        {
            this.mu    = mu;
            this.sigma = sigma;
        }

        public string Name { get; } = "Normal Distribution";
        public double GetMean() => mu;
        public double GetVariance() => sigma * sigma;
        public double Quantile(double p) => mu + sigma * Math.Sqrt(2) * SpecialFunctions.ErfInv(2 * p - 1);           
    }
}
