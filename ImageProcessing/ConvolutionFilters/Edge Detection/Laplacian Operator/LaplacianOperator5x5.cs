using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.Edge_Detection
{
    class LaplacianOperator5x5 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;


        public override double Factor { get; } = 1.0;


        public override string FilterName { get; } = "Laplacian Operator 3 x 3";


        public override double[,] Kernel { get; } = new double[,] { {-1, -1, -1, -1, -1 },
                                                                    {-1, -1, -1, -1, -1 },
                                                                    {-1, -1, 24, -1, -1 },
                                                                    {-1, -1, -1, -1, -1 },
                                                                    {-1, -1, -1, -1, -1 } };
    }
}
