using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.GaussianBlur3x3
{
    public class GaussianBlur3x3 : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0 / 16.0;
        public override string FilterName => "Gaussian Blur 3 x 3";
        public override double[,] Kernel
            =>
            new double[,] { {1, 2, 1 },
                            {2, 4, 2 },
                            {1, 2, 1 } };
    };
}

