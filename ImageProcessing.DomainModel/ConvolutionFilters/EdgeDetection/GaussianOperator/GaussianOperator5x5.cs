using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.GaussianOperator
{
    class GaussianOperator5x5 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0 / 159; 
        public override string FilterName { get; } = "Laplacian Operator 3 x 3";
        public override double[,] Kernel { get; } = new double[,] { { 2, 04, 05, 04, 2 },
                                                                    { 4, 09, 12, 09, 4 },
                                                                    { 5, 12, 15, 12, 5 },
                                                                    { 4, 09, 12, 09, 4 },
                                                                    { 2, 04, 05, 04, 2 }, };
    }
}
