using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.GaussianBlur
{
    /// <summary>
    /// Implements the <see cref="IConvolutionKernel"/>.
    /// </summary>
	public sealed class GaussianBlur3x3 : IConvolutionKernel
	{
        /// <inheritdoc />
		public double Bias { get; } = 0.0;

        /// <inheritdoc />
		public double Factor { get; } = 1.0 / 16.0;

        /// <inheritdoc />
		public string FilterName { get; } = nameof(GaussianBlur3x3);

        /// <inheritdoc />
		public ReadOnly2DArray<double> Kernel { get; }
			= new ReadOnly2DArray<double>(
			    new double[,] {
                    { 1, 2, 1 },
					{ 2, 4, 2 },
					{ 1, 2, 1 }
                });
	};
}
