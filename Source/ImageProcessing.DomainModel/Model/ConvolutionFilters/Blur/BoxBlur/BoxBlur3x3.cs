using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ConvolutionFilters.Blur.BoxBlur
{
	public class BoxBlur3x3 : AbstractConvolutionFilter
	{
		public override double Bias { get; } = 0.0;
		public override double Factor { get; } = 1.0 / 9.0;
		public override string FilterName { get; } = nameof(BoxBlur3x3);
		public override double[,] Kernel { get; }
			=
			new double[,] { {1, 1, 1 },
						    {1, 1, 1 },
							{1, 1, 1 } };

	}
}
