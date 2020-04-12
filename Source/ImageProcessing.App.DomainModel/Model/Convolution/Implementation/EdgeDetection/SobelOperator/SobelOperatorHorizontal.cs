using ImageProcessing.App.DomainModel.Convolution.Interface;

namespace ImageProcessing.App.DomainModel.Convolution.Implemetation.EdgeDetection.SobelOperator
{
    /// <summary>
    /// Implements the <see cref="IConvolutionFilter"/>.
    /// </summary>
    internal sealed class SobelOperatorHorizontal : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(SobelOperatorHorizontal);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { { -1, -2, -1 },
                            {  0,  0,  0 },
                            {  1,  2,  1 } };
    };
}

