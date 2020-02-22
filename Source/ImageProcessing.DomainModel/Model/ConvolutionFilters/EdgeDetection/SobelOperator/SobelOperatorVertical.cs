using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator
{
    public class SobelOperatorVertical : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0;
        public override string FilterName { get; } = nameof(SobelOperatorVertical);
        public override double[,] Kernel { get; }
            =
            new double[,] { { -1,  0, 1 },
                            { -2,  0, 2 },
                            { -1,  0, 1 } };
    }
}
