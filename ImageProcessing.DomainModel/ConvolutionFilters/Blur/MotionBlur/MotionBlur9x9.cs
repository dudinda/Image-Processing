using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.Blur.MotionBlur
{
    class MotionBlur9x9 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0 / 18.0;
        public override string FilterName { get; } = "Motion Blur 9 x 9";
        public override double[,] Kernel { get; } = new double[,] { {1, 0, 0, 0, 0, 0, 0, 0, 1 },
                                                                    {0, 1, 0, 0, 0, 0, 0, 1, 0 },
                                                                    {0, 0, 1, 0, 0, 0, 1, 0, 0 },
                                                                    {0, 0, 0, 1, 0, 1, 0, 0, 0 },
                                                                    {0, 0, 0, 0, 1, 0, 0, 0, 0 },
                                                                    {0, 0, 0, 1, 0, 1, 0, 0, 0 },
                                                                    {0, 0, 1, 0, 0, 0, 1, 0, 0 },
                                                                    {0, 1, 0, 0, 0, 0, 0, 1, 0 },
                                                                    {1, 0, 0, 0, 0, 0, 0, 0, 1} };
    }
}
