using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Sharpen
{
    public class Sharpen3x3 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0;
        public override string FilterName { get; } = nameof(Sharpen3x3);
        public override double[,] Kernel { get; }
            =
            new double[,] { { 0, -1,  0 },
                            {-1,  5, -1 },
                            { 0, -1,  0 } };
    }
}
