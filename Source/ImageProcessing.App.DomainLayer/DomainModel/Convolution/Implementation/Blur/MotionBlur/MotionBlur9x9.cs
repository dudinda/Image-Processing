using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.MotionBlur
{
    /// <summary>
    /// Implements the <see cref="IConvolutionFilter"/>.
    /// </summary>
    internal sealed class MotionBlur9x9 : IConvolutionFilter
    {
        /// <inheritdoc />
        public double Bias { get; } = 0.0;

        /// <inheritdoc />
        public double Factor { get; } = 1.0 / 18.0;

        /// <inheritdoc />
        public string FilterName { get; } = nameof(MotionBlur9x9);

        /// <inheritdoc />
        public ReadOnly2DArray<double> Kernel { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 1 }
                });
    }
}
