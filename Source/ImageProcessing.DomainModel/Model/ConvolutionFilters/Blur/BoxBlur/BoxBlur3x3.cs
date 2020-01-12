using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.Blur.BoxBlur
{
    public class BoxBlur3x3 : AbstractConvolutionFilter
    {
        public override double Bias => 0.0;
        public override double Factor => 1.0 / 9.0;
        public override string FilterName => nameof(BoxBlur3x3);
        public override double[,] Kernel 
            =>
            new double[,] { {1, 1, 1 },
                            {1, 1, 1 },
                            {1, 1, 1 } };
    }
}
