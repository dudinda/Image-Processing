using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class UniformDistribution : IDistribution
    {
        private double a { get; set; }
        private double b { get; set; }

        public UniformDistribution(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public string Name { get; } = "Uniform Distribution";
        public double GetMean() => (a + b) / 2;
        public double GetVariance() => (b - a) * (b - a) / 12;
        public double Quantile(double p) => a + p * (b - a);
    }
}
