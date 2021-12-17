using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.Convolution;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Convolution.Implementation
{
    internal class ConvolutionProviderWrapper : IConvolutionProviderWrapper
    {
        private readonly ConvolutionProvider _provider;

        public IConvolutionVisitableFactoryWrapper ConvolutionVisitableFactory { get; }
        public IConvolutionVisitorWrapper ConvolutionVisitor { get; }

        public ConvolutionProviderWrapper(
            IConvolutionVisitableFactoryWrapper factory,
            IConvolutionVisitorWrapper visitor)
        {
            ConvolutionVisitableFactory = factory;
            ConvolutionVisitor = visitor;

            _provider = new ConvolutionProvider(factory, visitor);
        }

        public virtual Bitmap ApplyFilter(Bitmap bmp, ConvKernel filter)
            => _provider.ApplyFilter(bmp, filter);
    }
}
