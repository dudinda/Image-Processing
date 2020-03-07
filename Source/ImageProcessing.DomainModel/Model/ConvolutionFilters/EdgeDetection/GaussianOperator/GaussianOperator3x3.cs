using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.GaussianOperator
{
    public class GaussianOperator3x3 : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0;
        public override string FilterName { get; } = nameof(GaussianOperator3x3);
        public override double[,] Kernel { get; }
            =
            new double[,] { { 1, 2, 1, },
                            { 2, 4, 2, },
                            { 1, 2, 1, } };
    }
}
