using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection
{
    public class LaplacianOperator3x3 : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0;
        public override string FilterName => nameof(LaplacianOperator3x3);
        public override double[,] Kernel
            =>
            new double[,] { {-1, -1, -1 },
                            {-1,  8, -1 },
                            {-1, -1, -1 } };
    }
}
