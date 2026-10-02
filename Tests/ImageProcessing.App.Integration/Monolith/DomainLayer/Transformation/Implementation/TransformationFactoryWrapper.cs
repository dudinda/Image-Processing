using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Transformation.Interface;
using ImageProcessing.App.Domain.Models.Transformation;
using ImageProcessing.App.Domain.Services.Factories.Transformation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Transformation.Implementation
{
    internal class TransformationFactoryWrapper : ITransformationFactoryWrapper
    {
        private readonly ITransformationFactory _factory;

        public TransformationFactoryWrapper(ITransformationFactory factory)
        {
            _factory = factory;
        }

        public virtual ITransformation Get(AffTransform model)
            => _factory.Get(model);
    }
}
