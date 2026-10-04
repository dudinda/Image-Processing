using ImageProcessing.App.Domain.Code.Collections;

namespace ImageProcessing.App.Domain.Models.Convolution.Implementation.Sharpen
{
    /// <summary>
    /// Implements the <see cref="IConvolutionKernel"/>.
    /// </summary>
    public sealed class Sharpen3x3 : IConvolutionKernel
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(Sharpen3x3);

        /// <inheritdoc />
        public ReadOnly2DArray<double> Kernel { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 0, -1,  0 },
                    {-1,  5, -1 },
                    { 0, -1,  0 }
                });
    }
}
