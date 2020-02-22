using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection
{
    public class LaplacianOperator3x3 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0;
        public override string FilterName { get; } = nameof(LaplacianOperator3x3);
        public override double[,] Kernel { get; }
            =
            new double[,] { {-1, -1, -1 },
                            {-1,  8, -1 },
                            {-1, -1, -1 } };
    }
}
