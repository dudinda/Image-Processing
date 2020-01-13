using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Blur.BoxBlur
{
    public class BoxBlur5x5 : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0 / 25.0;
        public override string FilterName => nameof(BoxBlur5x5);
        public override double[,] Kernel 
            =>
            new double[,] { {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 },
                            {1, 1, 1, 1, 1 } };
    }   
}
