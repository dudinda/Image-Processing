using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Distributions.TwoParameterDistributions
{
    class UniformDistribution : IDistribution
    {
        private double _a;
        private double _b;

        public UniformDistribution()
        {

        }

        public UniformDistribution(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public double FirstParameter { get { return _a; } }
        public double SecondParameter { get { return _b; } }

        public double GetMean() => (_a + _b) / 2;
        public double GetVariance() => (_b - _a) * (_b - _a) / 12;
        public double Quantile(double p) => _a + p * (_b - _a);

        public void SetParams((double, double) parms)
        {
            _a = parms.Item1;
            _b = parms.Item2;
        }
    }
}
