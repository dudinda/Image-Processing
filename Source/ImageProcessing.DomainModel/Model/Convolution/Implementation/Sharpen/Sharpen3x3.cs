using System.Runtime.CompilerServices;

using ImageProcessing.DomainModel.Convolution.Interface;

namespace ImageProcessing.DomainModel.Convolution.Implemetation.Sharpen
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    internal sealed class Sharpen3x3 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(Sharpen3x3);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { { 0, -1,  0 },
                            {-1,  5, -1 },
                            { 0, -1,  0 } };
    }
}
