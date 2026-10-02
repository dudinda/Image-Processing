using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Convolution.Interface;
using ImageProcessing.App.Domain.Providers.Visitors.Convolution.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.Convolution.Implementation
{
    internal class ConvolutionVisitorWrapper : IConvolutionVisitorWrapper
    {
        private readonly ConvolutionVisitor _visitor;

        public IConvolutionFactoryWrapper ConvolutionFactory { get; }
        public IConvolutionServiceWrapper ConvolutionService { get; }
        public IBitmapServiceWrapper BitmapService { get; }
        public ICacheServiceWrapper CacheService { get; }

        public ConvolutionVisitorWrapper(
            IConvolutionFactoryWrapper factory,
            IConvolutionServiceWrapper convolution,
            IBitmapServiceWrapper service)
        {
            ConvolutionFactory = factory;
            ConvolutionService = convolution;
            BitmapService = service;

            _visitor = new ConvolutionVisitor(factory, convolution, service);
        }

        public virtual Bitmap LoGOperator3x3(Bitmap bmp)
            => _visitor.LoGOperator3x3(bmp);

        public virtual Bitmap SobelOverator3x3(Bitmap bmp)
            => _visitor.SobelOverator3x3(bmp);

        public virtual Bitmap Operator(Bitmap bmp, ConvKernel filter)
            => Operator(bmp, filter);
    }
}
