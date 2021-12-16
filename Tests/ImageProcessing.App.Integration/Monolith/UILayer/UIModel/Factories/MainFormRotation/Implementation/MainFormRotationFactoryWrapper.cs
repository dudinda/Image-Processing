
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormRotation.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Model.Rotate;

namespace ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormRotation.Implementation
{
    internal class MainFormRotationFactoryWrapper : IMainFormRotationFactoryWrapper
    {
        private readonly IMainFormRotationFactory _factory;

        public MainFormRotationFactoryWrapper(
            IMainFormRotationFactory factory)
        {
            _factory = factory;
        }

        public virtual RotateContainer Get(ImageContainer model)
        {
            return _factory.Get(model);
        }
    }
}
