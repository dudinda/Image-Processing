using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Transformation.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Transformation.Implementation
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
