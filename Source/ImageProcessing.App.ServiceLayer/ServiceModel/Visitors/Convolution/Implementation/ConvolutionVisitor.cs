using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.CompoundModels.Visitors.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.App.ServiceLayer.CompoundModels.Visitors.Convolution.Implementation
{
    internal sealed class ConvolutionVisitor : IConvolutionVisitor
    {
        private readonly IConvolutionFilterFactory _factory;
        private readonly IConvolutionFilterService _convolution;
        private readonly IBitmapService _service;
        private readonly ICacheService<Bitmap> _cache;

        public ConvolutionVisitor(
            IConvolutionFilterFactory factory,
            IConvolutionFilterService convolution,
            IBitmapService service,
            ICacheService<Bitmap> cache)
        {
            _factory = factory;
            _convolution = convolution;
            _service = service;
            _cache = cache;
        }

        public Bitmap LoGOperator3x3(Bitmap bmp)
             => Operator(
                   Operator(bmp, ConvolutionFilter.GaussianBlur3x3),
                   ConvolutionFilter.LaplacianOperator3x3);

        public Bitmap Operator(Bitmap bmp, ConvolutionFilter filter)
        => _cache.GetOrCreate(filter,
            () => _convolution.Convolution(bmp, _factory.Get(filter))
        );

        public Bitmap SobelOverator3x3(Bitmap bmp)
        {
            using (var copy = new Bitmap(bmp))
            {
                var yDerivative = Task.Run(
                    () => Operator(bmp, ConvolutionFilter.SobelOperatorHorizontal3x3)
                );

                var xDerivative = Task.Run(
                    () => Operator(copy, ConvolutionFilter.SobelOperatorVertical3x3)
                );

                return _cache.GetOrCreate(ConvolutionFilter.SobelOperator3x3,
                    () => _service.Magnitude(xDerivative.Result, yDerivative.Result)
                );
            }
        }
    }
}
