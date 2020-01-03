using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.GaussianOperator
{
    class GaussianOperator3x3 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0;
        public override string FilterName { get; } = "Laplacian Operator 3 x 3";
        public override double[,] Kernel { get; } = new double[,] { { 1, 2, 1, },
                                                                    { 2, 4, 2, },
                                                                    { 1, 2, 1, } };
    }
}
