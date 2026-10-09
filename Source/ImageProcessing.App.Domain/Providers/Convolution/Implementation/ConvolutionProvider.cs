using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.VisitableFactory.Convolution;
using ImageProcessing.App.Domain.Providers.Visitors.Convolution;

namespace ImageProcessing.App.Domain.Providers.Convolution.Implementation
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
