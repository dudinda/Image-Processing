using System.Runtime.CompilerServices;

using ImageProcessing.DomainModel.Convolution.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.DomainModel.Convolution.Implemetation.Blur.GaussianBlur
{
    /// <summary>
    /// Implements <see cref="IConvolutionFilter"/>.
    /// </summary>
	internal sealed class GaussianBlur5x5 : IConvolutionFilter
	{
        /// <inheritdoc />
		public double Bias { get; } = 0.0;

        /// <inheritdoc />
		public double Factor { get; } = 1.0 / 159.0;

        /// <inheritdoc />
		public string FilterName { get; } = nameof(GaussianBlur5x5);

        /// <inheritdoc />
		public double[,] Kernel { get; }
			=
			new double[,] { {2, 04, 05, 04, 2  },
							{4, 09, 12, 09, 4  },
							{5, 12, 15, 12, 5, },
							{4, 09, 12, 09, 4  },
							{2, 04, 05, 04, 2  } };
	}
}
