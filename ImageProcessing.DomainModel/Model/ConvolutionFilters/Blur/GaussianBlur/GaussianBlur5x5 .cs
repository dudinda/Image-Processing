using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.GaussianBlur5x5
{
    public class GaussianBlur5x5 : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0 / 159.0;
        public override string FilterName => "Gaussian Blur 5 x 5";
        public override double[,] Kernel
            =>
            new double[,] { {2, 04, 05, 04, 2  },
                            {4, 09, 12, 09, 4  },
                            {5, 12, 15, 12, 5, },
                            {4, 09, 12, 09, 4  },
                            {2, 04, 05, 04, 2  } };
    }
}

