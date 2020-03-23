using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Factory.Convolution.Interface;
using ImageProcessing.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.ServiceLayer.Providers.Implementation.Convolution
{
    public sealed class ConvolutionServiceProvider : IConvolutionServiceProvider
    {
        private readonly IConvolutionFilterFactory _convolutionFilterFactory;
        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IBitmapService _bitmapService;
        private readonly ICacheService<Bitmap> _cache;

        public ConvolutionServiceProvider(IConvolutionFilterFactory convolutionFilterFactory,
                                          IConvolutionFilterService convolutionFilterService,
                                          IBitmapService bitmapService,
                                          ICacheService<Bitmap> cache)
        {
            _convolutionFilterFactory = Requires.IsNotNull(
                convolutionFilterFactory, nameof(convolutionFilterFactory));
            _convolutionFilterService = Requires.IsNotNull(
                convolutionFilterService, nameof(convolutionFilterService));
            _bitmapService = Requires.IsNotNull(
                bitmapService, nameof(bitmapService));
            _cache = Requires.IsNotNull(
                cache, nameof(cache));
        }

        public Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            switch (filter)
            {
                case ConvolutionFilter.SobelOperator3x3:
                    var cpy = new Bitmap(bmp);

                    var yDerivative = Task.Run(
                        () => GetFilter(bmp, ConvolutionFilter.SobelOperatorHorizontal3x3)
                    );

                    var xDerivative = Task.Run(
                        () => GetFilter(cpy, ConvolutionFilter.SobelOperatorVertical3x3)
                    );

                    return _cache.GetOrCreate(filter,
                        () => _bitmapService
                                  .Magnitude(xDerivative.Result,
                                             yDerivative.Result
                                  )
                              );

                case ConvolutionFilter.LoGOperator3x3:
                    return GetFilter(
                        GetFilter(bmp, ConvolutionFilter.GaussianBlur3x3),
                        ConvolutionFilter.LaplacianOperator3x3
                    );

                default: return filter.PartitionOver(
                    (ConvolutionFilter.BoxBlur3x3, ConvolutionFilter.SobelOperatorVertical3x3),
                    () => GetFilter(bmp, filter)
                );
            }

            Bitmap GetFilter(Bitmap src, ConvolutionFilter convolution)
                => _cache.GetOrCreate(convolution,
                   () =>
                   _convolutionFilterService
                       .Convolution(src,
                           _convolutionFilterFactory
                               .Get(convolution)
                       )
                   );
        }
    }
}
