using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Transformation;
using ImageProcessing.App.Domain.Services.Factories.Transformation;

namespace ImageProcessing.App.Domain.Providers.Transformation.Implementation
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
