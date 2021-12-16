using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormZoom.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.Model.Zoom;

namespace ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormZoom.Implementation
{
    internal class MainFormZoomFactoryWrapper : IMainFormZoomFactoryWrapper
    {
        private readonly IMainFormZoomFactory _factory;

        public MainFormZoomFactoryWrapper(
            IMainFormZoomFactory factory)
        {
            _factory = factory;
        }

        public virtual ZoomContainer Get(ImageContainer model)
        {
            return _factory.Get(model);
        }
    }
}
