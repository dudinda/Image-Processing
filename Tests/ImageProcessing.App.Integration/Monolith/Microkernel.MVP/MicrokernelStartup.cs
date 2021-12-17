using System;

using ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Microkernel.MVP
{
    internal sealed class MicrokernelStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            builder
                .RegisterSingleton<IEventAggregatorWrapper, EventAggregatorWrapper>()
                .Resolve<IAppController>().GetType().GetProperty(nameof(IAppController.Aggregator))
                .SetValue(builder.Resolve<IAppController>(), builder.Resolve<IEventAggregatorWrapper>());
        }
    }
}
