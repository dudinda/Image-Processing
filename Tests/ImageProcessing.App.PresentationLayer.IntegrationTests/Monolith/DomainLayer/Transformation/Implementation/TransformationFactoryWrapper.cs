using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Transformation.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Transformation.Implementation
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
