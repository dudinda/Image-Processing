using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.Emboss
{
    class Emboss3x3 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 128.0;


        public override double Factor { get; } = 1.0;


        public override string FilterName { get; } = "Emboss 3 x 3";


        public override double[,] Kernel { get; } = new double[,] { { 2,  0,  0 },
                                                                    { 0, -1,  0 },
                                                                    { 0,  0, -1 } };
    }
}
