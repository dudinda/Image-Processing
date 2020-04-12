using ImageProcessing.App.DomainModel.Convolution.Interface;

namespace ImageProcessing.App.DomainModel.Convolution.Implemetation.Emboss
{
    /// <summary>
    /// Implements the <see cref="IConvolutionFilter"/>.
    /// </summary>
    internal sealed class Emboss3x3 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 128.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(Emboss3x3);

        /// <inheritdoc />
        public double[,] Kernel { get; }
            =
            new double[,] { { 2,  0,  0 },
                            { 0, -1,  0 },
                            { 0,  0, -1 } };
    }
}
