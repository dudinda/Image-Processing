using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.CompoundModels.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.CompoundModels.Visitors.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

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
        public Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter)
            => _factory.Get(filter).Accept(_visitor).Filter(bmp);
    }
}
