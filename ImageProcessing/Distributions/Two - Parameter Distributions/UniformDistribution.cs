using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.Two___Parameter_Distributions
{
    class UniformDistribution : IDistribution
    {

        public UniformDistribution(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        private double a { get; set; }
        private double b { get; set; }

        public string Name { get; } = "Uniform Distribution";

        public double GetMean() => (a + b) / 2;

        public double GetVariance() => (b - a) * (b - a) / 12;

        public double Quantile(double p) => a + p * (b - a);

    }
}
