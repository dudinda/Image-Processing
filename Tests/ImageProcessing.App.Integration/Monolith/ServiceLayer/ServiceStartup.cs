
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer
{
    internal class ServiceStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new DomainStartup().Build(builder);
        }
    }
}
