using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Blur.MotionBlur
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    public class MotionBlur9x9 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0 / 18.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(MotionBlur9x9);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { {1, 0, 0, 0, 0, 0, 0, 0, 1 },
                            {0, 1, 0, 0, 0, 0, 0, 1, 0 },
                            {0, 0, 1, 0, 0, 0, 1, 0, 0 },
                            {0, 0, 0, 1, 0, 1, 0, 0, 0 },
                            {0, 0, 0, 0, 1, 0, 0, 0, 0 },
                            {0, 0, 0, 1, 0, 1, 0, 0, 0 },
                            {0, 0, 1, 0, 0, 0, 1, 0, 0 },
                            {0, 1, 0, 0, 0, 0, 0, 1, 0 },
                            {1, 0, 0, 0, 0, 0, 0, 0, 1} };
    }
}
