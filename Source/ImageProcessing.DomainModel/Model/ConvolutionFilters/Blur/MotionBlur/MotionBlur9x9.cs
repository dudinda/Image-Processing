using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Blur.MotionBlur
{
    public class MotionBlur9x9 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0 / 18.0;
        public override string FilterName { get; } = nameof(MotionBlur9x9);
        public override double[,] Kernel { get; }
            =
            new double[,] { {1, 0, 0, 0, 0, 0, 0, 0, 1 },
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
