using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator
{
    class SobelOperatorHorizontal : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0;
        public override string FilterName { get; } = "Sobel Operator";
        public override double[,] Kernel { get; } = new double[,] { { -1, -2, -1 },
                                                                    {  0,  0,  0 },
                                                                    {  1,  2,  1 } };
    };
}

