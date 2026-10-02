using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Morphology.Interface;
using ImageProcessing.App.Domain.Models.Morphology;
using ImageProcessing.App.Domain.Services.Factories.Morphology;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Morphology.Implementation
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
