using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator
{
    public class SobelOperatorVertical : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0;
        public override string FilterName => "Sobel Operator";
        public override double[,] Kernel
            =>
            new double[,] { { -1,  0, 1 },
                            { -2,  0, 2 },
                            { -1,  0, 1 } };
    }
}
