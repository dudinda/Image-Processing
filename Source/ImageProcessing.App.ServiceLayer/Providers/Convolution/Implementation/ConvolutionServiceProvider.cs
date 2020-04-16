using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExtensions;
using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainModel.Factory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.Convolution
{
    public sealed class ConvolutionServiceProvider : IConvolutionServiceProvider
    {
        private static readonly Dictionary<string, CommandAttribute>
            _command = typeof(ConvolutionServiceProvider).GetCommands();

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

            try
            {
                return _command[
                    filter.ToString()
                ].Method.Invoke(this, new object[] { bmp, filter }) as Bitmap;
            }
            catch(KeyNotFoundException)
            {
                return GetFilter(bmp, filter);
            }
        }

        [Command(nameof(ConvolutionFilter.LoGOperator3x3))]
        private Bitmap LoG3x3(Bitmap bmp, ConvolutionFilter filter)
        {
            return GetFilter(
                       GetFilter(bmp, ConvolutionFilter.GaussianBlur3x3),
                       ConvolutionFilter.LaplacianOperator3x3
                   );
        }

        [Command(nameof(ConvolutionFilter.SobelOperator3x3))]
        private Bitmap SobelOperator(Bitmap bmp, ConvolutionFilter filter)
        {
            using (var cpy = new Bitmap(bmp))
            {
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
            }
        }

        private Bitmap GetFilter(Bitmap src, ConvolutionFilter convolution)
            => _cache.GetOrCreate(convolution,
               () =>_convolutionFilterService
                   .Convolution(src,_convolutionFilterFactory.Get(convolution)
           )
       );
    }
}
