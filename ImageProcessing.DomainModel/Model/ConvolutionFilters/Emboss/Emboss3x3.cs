using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.ConvolutionFilters.Emboss
{
    public class Emboss3x3 : AbstractConvolutionFilter
    {
        public override double Bias => 128.0;
        public override double Factor => 1.0;
        public override string FilterName => nameof(Emboss3x3);
        public override double[,] Kernel
            =>
            new double[,] { { 2,  0,  0 },
                            { 0, -1,  0 },
                            { 0,  0, -1 } };
    }
}
