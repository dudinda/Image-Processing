using System;
using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.Two___Parameter_Distributions
{
    class LaplaceDistribution : IDistribution
    {

        public LaplaceDistribution(double mu, double b)
        {
            this.mu = mu;
            this.b  = b;
        }

        private double mu { get; set; }
        private double b  { get; set; }

        public string Name { get; } = "Laplace Distribution";


        public double GetMean() => mu;

        public double GetVariance() => 2 * b * b;


        public double Quantile(double p) => mu + b * Math.Sign(p - 0.5) * Math.Log(1 - 2 * Math.Abs(p - 0.5));
    }
}
