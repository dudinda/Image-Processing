using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.GaussianOperator
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    public class GaussianOperator3x3 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(GaussianOperator3x3);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { { 1, 2, 1, },
                            { 2, 4, 2, },
                            { 1, 2, 1, } };
    }
}
