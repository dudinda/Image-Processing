using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.Blur.BoxBlur
{
    class BoxBlur3x3 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0 / 9.0;
        public override string FilterName { get; } = "Box Blur 3 x 3";  
        public override double[,] Kernel { get; } = new double[,] { {1, 1, 1 },
                                                                    {1, 1, 1 },
                                                                    {1, 1, 1 } };
    }
}
