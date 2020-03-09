using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Emboss
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    public class Emboss3x3 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 128.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(Emboss3x3);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { { 2,  0,  0 },
                            { 0, -1,  0 },
                            { 0,  0, -1 } };
    }
}
