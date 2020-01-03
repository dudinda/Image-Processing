using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class UniformDistribution : IDistribution
    {
        private readonly double _a;
        private readonly double _b;

        public UniformDistribution(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public string Name { get; } = "Uniform Distribution";
        public double GetMean() => (_a + _b) / 2;
        public double GetVariance() => (_b - _a) * (_b - _a) / 12;
        public double Quantile(double p) => _a + p * (_b - _a);
    }
}
