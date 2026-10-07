using ImageProcessing.App.Presentation.IntegrationTests.Fakes;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.Microkernel.MVP.Models;
using ImageProcessing.Microkernel.MVP.Services.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.Services.Providers;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Microkernel.MVP
{
    internal sealed class Startup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            builder
                .RegisterSingleton<IEventAggregatorWrapper>(factory =>
                {
                    var aggregator = new EventAggregatorWrapper();
                    var controller = AppController.Controller;
                    controller.Aggregator = aggregator;
                    return aggregator;
                });
        }
    }
}
