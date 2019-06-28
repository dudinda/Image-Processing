using System;
using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.One___Parameter_Distributions
{
    class ExponentialDistribution : IDistribution
    {
       
        public ExponentialDistribution(double lambda)
        {
            this.lambda = lambda;
        }
        
        private double lambda { get; set; }

        public string Name { get; } = "Exponential Distribution";

        public double GetMean() => 1 / lambda;


        public double GetVariance() => 1 / (lambda * lambda);


        public double Quantile(double p) {

            if(p >= 1)
            {
                return 0;
            }
            return -Math.Log(1 - p) / lambda;

        }
    }
}
