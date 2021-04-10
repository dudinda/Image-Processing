using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.GaussianBlur
{
    /// <summary>
    /// Implements the <see cref="IConvolutionKernel"/>.
    /// </summary>
	public sealed class GaussianBlur5x5 : IConvolutionKernel
	{
        /// <inheritdoc />
		public double Bias { get; } = 0.0;

        /// <inheritdoc />
		public double Factor { get; } = 1.0 / 159.0;

        /// <inheritdoc />
		public string FilterName { get; } = nameof(GaussianBlur5x5);

        /// <inheritdoc />
		public ReadOnly2DArray<double> Kernel { get; }
			= new ReadOnly2DArray<double>(
			    new double[,] {
                    { 2, 04, 05, 04, 2 },
					{ 4, 09, 12, 09, 4 },
					{ 5, 12, 15, 12, 5 },
					{ 4, 09, 12, 09, 4 },
					{ 2, 04, 05, 04, 2 }
                });
	}
}
