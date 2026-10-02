using System;

using ImageProcessing.App.Presentation.IntegrationTests.Fakes;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Microkernel.MVP
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
