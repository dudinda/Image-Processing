using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.ServiceLayer.Providers.Convolution;
using ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.Services.Providers
{
    public class ConvolutionFilterServiceProvider : IConvolutionFilterServiceProvider
    {
        private readonly IConvolutionFilterFactory _convolutionFilterFactory;
        private readonly IConvolutionFilterService _convolutionFilterService;

        public ConvolutionFilterServiceProvider(IConvolutionFilterFactory convolutionFilterFactory,
                                                IConvolutionFilterService convolutionFilterService)
        {
            _convolutionFilterFactory = Requires.IsNotNull(
                convolutionFilterFactory, nameof(convolutionFilterFactory)
            );

            _convolutionFilterService = Requires.IsNotNull(
                convolutionFilterService, nameof(convolutionFilterService)
            );
        }

        public Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            switch (filter)
            {
                case ConvolutionFilter.BoxBlur3x3:
                case ConvolutionFilter.BoxBlur5x5:
                case ConvolutionFilter.EmbossOperator3x3:
                case ConvolutionFilter.GaussianBlur3x3:
                case ConvolutionFilter.GaussianBlur5x5:
                case ConvolutionFilter.GaussianOperator3x3:
                case ConvolutionFilter.GaussianOperator5x5:
                case ConvolutionFilter.LaplacianOperator3x3:
                case ConvolutionFilter.LaplacianOperator5x5:
                case ConvolutionFilter.MotionBlur9x9:
                case ConvolutionFilter.SharpenOperator3x3:
                case ConvolutionFilter.SobelOperatorHorizontal3x3:
                case ConvolutionFilter.SobelOperatorVertical3x3:

                    return GetFilter(bmp, filter);
                   
                case ConvolutionFilter.SobelOperator3x3:

                    var yDerivative = Task.Run(
                        () => GetFilter(bmp, ConvolutionFilter.SobelOperatorHorizontal3x3)
                    );

                    var xDerivative = Task.Run(
                        () => GetFilter(bmp, ConvolutionFilter.SobelOperatorVertical3x3)
                    );

                    return BitmapExtension.Magnitude(xDerivative.Result, yDerivative.Result);

                case ConvolutionFilter.LoGOperator3x3:

                    return GetFilter(
                        GetFilter(bmp, ConvolutionFilter.GaussianBlur3x3),
                        ConvolutionFilter.LaplacianOperator3x3
                    );

                default: throw new NotImplementedException(nameof(filter));
            }

            Bitmap GetFilter(Bitmap src, ConvolutionFilter convolution)
                => _convolutionFilterService
                       .Convolution(src,
                           _convolutionFilterFactory
                               .GetFilter(convolution)
                       );
        }
    }
}