using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.Convolution.Interface;
using ImageProcessing.App.Domain.Providers.Convolution.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.Providers.Convolution.Implementation
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
