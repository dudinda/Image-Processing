using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.GaussianBlur
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
	public class GaussianBlur3x3 : IConvolutionFilter
	{
        /// <inheritdoc />
		public double Bias { get; } = 0.0;

        /// <inheritdoc />
		public double Factor { get; } = 1.0 / 16.0;

        /// <inheritdoc />
		public string FilterName { get; } = nameof(GaussianBlur3x3);

        /// <inheritdoc />
		public double[,] Kernel { get; }
			=
			new double[,] { {1, 2, 1 },
							{2, 4, 2 },
							{1, 2, 1 } };
	};
}
