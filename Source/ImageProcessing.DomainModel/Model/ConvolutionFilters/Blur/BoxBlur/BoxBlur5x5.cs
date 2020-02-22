using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Blur.BoxBlur
{
    public class BoxBlur5x5 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 0.0;
        public override double Factor { get; } = 1.0 / 25.0;
        public override string FilterName { get; } = nameof(BoxBlur5x5);
        public override double[,] Kernel { get; }
            =
			new double[,] { {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 } };
    }   
}
