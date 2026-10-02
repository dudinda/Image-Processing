using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Transformation.Interface;
using ImageProcessing.App.Domain.Providers.Transformation.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.Providers.Transformation.Implementation
{
    internal class TransformationProviderWrapper : ITransformationProviderWrapper
    {
        private readonly TransformationProvider _provider;

        public ITransformationFactoryWrapper TransformationFactory { get; }

        public TransformationProviderWrapper(
            ITransformationFactoryWrapper factory)
        {
            TransformationFactory = factory;
            _provider = new TransformationProvider(factory);
        }

        public virtual Bitmap Apply(Bitmap bmp, double x, double y, AffTransform transform)
            => _provider.Apply(bmp, x, y, transform);
    }
}
