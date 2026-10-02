using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.Models.Transformation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Transformation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Transformation.Implementation
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
