using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.BinaryOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Morphology.Interface;

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
