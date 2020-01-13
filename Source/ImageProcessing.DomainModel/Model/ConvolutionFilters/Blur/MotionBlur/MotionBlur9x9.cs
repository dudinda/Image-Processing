using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Blur.MotionBlur
{
    public class MotionBlur9x9 : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0 / 18.0;
        public override string FilterName => nameof(MotionBlur9x9);
        public override double[,] Kernel
            =>
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
