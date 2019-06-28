using System;
using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.One___Parameter_Distributions
{
    class RayleighDistribution : IDistribution
    {
        public RayleighDistribution(double sigma)
        {
            this.sigma = sigma;
        }

        private double sigma { get; set; }

        public string Name { get; } = "Rayleigh Distribution";

        public double GetMean() => sigma * Math.Sqrt(Math.PI / 2);


        public double GetVariance() => (2 - Math.PI / 2) * sigma * sigma;


        public double Quantile(double p)
        {
            if(p >= 1)
            {
                return 0;
            }

            return sigma* Math.Sqrt(-2 * Math.Log(1 - p));
        }
    }
}
