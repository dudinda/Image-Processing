using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories.Morphology.Operator.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Morphology.Interface;
using ImageProcessing.App.ServiceLayer.Models.Morphology;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Morphology.Implementation
{
    internal class MorphologyFactoryWrapper : IMorphologyFactoryWrapper
    {
        private readonly IMorphologyFactory _factory;

        public MorphologyFactoryWrapper(IMorphologyFactory factory)
        {
            _factory = factory;
        }

        public virtual IMorphologyUnary Get(MorphOperator model)
            => _factory.Get(model);

        public virtual IMorphologyBinary GetBinary(MorphOperator filter)
            => _factory.GetBinary(filter);
    }
}
