using ImageProcessing.DomainModel.Convolution.Interface;

namespace ImageProcessing.DomainModel.Convolution.Implemetation.EdgeDetection.SobelOperator
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
    internal sealed class SobelOperatorVertical : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(SobelOperatorVertical);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { { -1,  0, 1 },
                            { -2,  0, 2 },
                            { -1,  0, 1 } };
    }
}
