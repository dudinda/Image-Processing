using ImageProcessing.App.DomainLayer.Convolution.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.Convolution.Implemetation.Emboss
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
        public ReadOnly2DArray<double> Kernel { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 2,  0,  0 },
                    { 0, -1,  0 },
                    { 0,  0, -1 }
                });
    }
}
