using ImageProcessing.App.Domain.Code.Collections;

namespace ImageProcessing.App.Domain.Models.Convolution.Implementation.Blur.BoxBlur
{
    /// <summary>
    /// Implements the <see cref="IConvolutionKernel"/>.
    /// </summary>
    public sealed class BoxBlur3x3 : IConvolutionKernel
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0 / 9.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(BoxBlur3x3);

        /// <inheritdoc />
        public ReadOnly2DArray<double> Kernel { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 1, 1, 1 },
                    { 1, 1, 1 },
                    { 1, 1, 1 }
                });
    }
}
