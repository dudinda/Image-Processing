using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.GaussianBlur
{
    public class GaussianBlur5x5 : AbstractConvolutionFilter
    {
        public override double Bias { get; } =0.0;
        public override double Factor { get; } = 1.0 / 159.0;
        public override string FilterName { get; } = nameof(GaussianBlur5x5);
        public override double[,] Kernel { get; }
            =
			new double[,] { {2, 04, 05, 04, 2  },
                            {4, 09, 12, 09, 4  },
                            {5, 12, 15, 12, 5, },
                            {4, 09, 12, 09, 4  },
                            {2, 04, 05, 04, 2  } };
    }
}

