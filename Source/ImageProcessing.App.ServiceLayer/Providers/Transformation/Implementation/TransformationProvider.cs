using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Transformation.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Transformation.Implementation
{
    public sealed class TransformationProvider : ITransformationProvider
    {
        private readonly ITransformationFactory _factory;

        public TransformationProvider(
            ITransformationFactory factory)
        {
            _factory = factory;
        }

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, double x, double y, AffTransform transform)
            => _factory.Get(transform).Transform(bmp, x, y);
    }
}
