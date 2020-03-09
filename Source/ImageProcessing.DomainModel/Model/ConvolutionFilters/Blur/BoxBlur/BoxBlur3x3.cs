using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Blur.BoxBlur
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    public class BoxBlur3x3 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0 / 9.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(BoxBlur3x3);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { {1, 1, 1 },
                            {1, 1, 1 },
                            {1, 1, 1 } };
    }
}
