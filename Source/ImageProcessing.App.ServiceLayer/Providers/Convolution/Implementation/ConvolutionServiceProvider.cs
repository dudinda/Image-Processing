using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.Convolution
{
    /// <inheritdoc cref="IConvolutionServiceProvider"/>
    public sealed class ConvolutionServiceProvider : IConvolutionServiceProvider
    {
        private static readonly Dictionary<string, CommandAttribute>
            _composite = typeof(ConvolutionServiceProvider).GetCommands();

        private readonly IConvolutionFilterFactory _convolutionFilterFactory;
        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IBitmapService _bitmapService;
        private readonly ICacheService<Bitmap> _cache;

        public ConvolutionServiceProvider(IConvolutionFilterFactory convolutionFilterFactory,
                                          IConvolutionFilterService convolutionFilterService,
                                          IBitmapService bitmapService,
                                          ICacheService<Bitmap> cache)
        {
            _convolutionFilterFactory = convolutionFilterFactory;
            _convolutionFilterService = convolutionFilterService;
            _bitmapService = bitmapService;
            _cache = cache;
        }

        /// <inheritdoc/>
        public Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter)
        {
            var key = filter.ToString();

            if(_composite.ContainsKey(key))
            {
                return (Bitmap)_composite[
                   key
               ].Method.Invoke(this, new object[] { bmp, filter });
            }

            return GetFilter(bmp, filter);
        }

        [Command(nameof(ConvolutionFilter.LoGOperator3x3))]
        private Bitmap GetLoG3x3Command(Bitmap bmp, ConvolutionFilter filter)
            => GetFilter(
                GetFilter(bmp, ConvolutionFilter.GaussianBlur3x3),
                ConvolutionFilter.LaplacianOperator3x3
            );
        

        [Command(nameof(ConvolutionFilter.SobelOperator3x3))]
        private Bitmap GetSobelOperatorCommand(Bitmap bmp, ConvolutionFilter filter)
        {
            using (var copy = new Bitmap(bmp))
            {
                var yDerivative = Task.Run(
                    () => GetFilter(bmp, ConvolutionFilter.SobelOperatorHorizontal3x3)
                );

                var xDerivative = Task.Run(
                    () => GetFilter(copy, ConvolutionFilter.SobelOperatorVertical3x3)
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
                   .Convolution(src, _convolutionFilterFactory.Get(convolution)
           )
       );
    }
}
