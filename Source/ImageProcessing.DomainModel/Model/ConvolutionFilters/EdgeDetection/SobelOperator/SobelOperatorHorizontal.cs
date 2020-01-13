using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator
{
    public class SobelOperatorHorizontal : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0;
        public override string FilterName => nameof(SobelOperatorHorizontal);
        public override double[,] Kernel
            =>
            new double[,] { { -1, -2, -1 },
                            {  0,  0,  0 },
                            {  1,  2,  1 } };
    };
}

