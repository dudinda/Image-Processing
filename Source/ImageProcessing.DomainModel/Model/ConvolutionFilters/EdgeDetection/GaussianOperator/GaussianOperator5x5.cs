using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection.GaussianOperator
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    public class GaussianOperator5x5 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0 / 159;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(GaussianOperator5x5);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { { 2, 04, 05, 04, 2 },
                            { 4, 09, 12, 09, 4 },
                            { 5, 12, 15, 12, 5 },
                            { 4, 09, 12, 09, 4 },
                            { 2, 04, 05, 04, 2 }, };
    }
}
