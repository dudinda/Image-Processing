using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.Integration.Monolith.UILayer
{
    internal sealed class UIStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new ServiceStartup().Build(builder);
        }
    }
}
