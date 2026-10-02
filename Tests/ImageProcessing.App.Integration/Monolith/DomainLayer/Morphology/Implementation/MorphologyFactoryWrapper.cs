using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Morphology.Interface;
using ImageProcessing.App.ServiceLayer.Models.Morphology;
using ImageProcessing.App.ServiceLayer.Services.Factories.Morphology;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Morphology.Implementation
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
