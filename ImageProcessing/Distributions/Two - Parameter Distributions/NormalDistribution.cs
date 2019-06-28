using MathNet.Numerics;
using System;
using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.Two___Parameter_Distributions
{
    class NormalDistribution : IDistribution
    {

        public NormalDistribution(double mu, double sigma)
        {
            this.mu    = mu;
            this.sigma = sigma;
        }


        public string Name { get; } = "Normal Distribution";
      

        private double mu    { get; set; }
        private double sigma { get; set; }

        public double GetMean() => mu;


        public double GetVariance() => sigma * sigma;


        public double Quantile(double p) => mu + sigma * Math.Sqrt(2) * SpecialFunctions.ErfInv(2 * p - 1);
           
        
    }
}
