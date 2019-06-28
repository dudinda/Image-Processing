using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.Sharpen
{
    class Sharpen3x3 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;


        public override double Factor { get; } = 1.0;


        public override string FilterName { get; } = "Sharpen 3 x 3";


        public override double[,] Kernel { get; } = new double[,] { { 0, -1,  0 },
                                                                    {-1,  5, -1 },
                                                                    { 0, -1,  0 } };

    }
}
