using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.EdgeDetection
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    public class LaplacianOperator3x3 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(LaplacianOperator3x3);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { {-1, -1, -1 },
                            {-1,  8, -1 },
                            {-1, -1, -1 } };
    }
}
