using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.Convolution
{
    /// <inheritdoc cref="IConvolutionServiceProvider"/>
    internal sealed class ConvolutionServiceProvider : IConvolutionServiceProvider
    {
        private readonly ICovolutionVisitableFactory _factory;
        private readonly IConvolutionVisitor _visitor;

        public ConvolutionServiceProvider(
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
