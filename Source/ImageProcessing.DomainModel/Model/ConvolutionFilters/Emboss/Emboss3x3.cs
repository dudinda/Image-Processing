using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Emboss
{
    public class Emboss3x3 : AbstractConvolutionFilter
    {
        public override double Bias { get; } = 128.0;
        public override double Factor { get; } = 1.0;
        public override string FilterName { get; } = nameof(Emboss3x3);
        public override double[,] Kernel { get; }
            =
            new double[,] { { 2,  0,  0 },
                            { 0, -1,  0 },
                            { 0,  0, -1 } };
    }
}
