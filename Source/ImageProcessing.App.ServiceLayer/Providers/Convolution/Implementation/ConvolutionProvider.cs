using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Providers.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.VisitableFactory.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Visitors.Convolution;

namespace ImageProcessing.App.ServiceLayer.Providers.Convolution.Implementation
{
    /// <inheritdoc cref="IConvolutionProvider"/>
    public sealed class ConvolutionProvider : IConvolutionProvider
    {
        private readonly ICovolutionVisitableFactory _factory;
        private readonly IConvolutionVisitor _visitor;

        public ConvolutionProvider(
            ICovolutionVisitableFactory factory,
            IConvolutionVisitor visitor)
        {
            _factory = factory;
            _visitor = visitor;
        }

        /// <inheritdoc/>
        public Bitmap ApplyFilter(Bitmap bmp, ConvKernel filter)
            => _factory.Get(filter).Accept(_visitor).Filter(bmp);
    }
}
