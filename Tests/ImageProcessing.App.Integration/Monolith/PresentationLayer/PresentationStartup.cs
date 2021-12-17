using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class PresentationStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new ServiceStartup().Build(builder);
        }
    }
}
