using System.Drawing;

using ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes;
using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.ServiceLayer.Services.Cache.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.PresentationLayer.UnitTests
{
    internal sealed class MainPresenterTestStartup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {

            builder.RegisterSingleton<IEventAggregatorFake, EventAggregatorFake>();

            var controller = builder.Resolve<IAppController>();
            var aggregator = builder.Resolve<IEventAggregatorFake>();

            controller
                .GetType()
                .GetProperty(nameof(controller.Aggregator))
                .SetValue(controller, aggregator);

            builder.RegisterSingleton<IManualResetEventService, ManualResetEventService>();


            builder.RegisterTransientInstance<IAppControllerFake>(Substitute.ForPartsOf<AppControllerFake>(controller))
                   .RegisterSingletonInstance<INonBlockDialogService>(Substitute.ForPartsOf<NonBlockDialogServiceFake>())
                   .RegisterTransientInstance<ICacheService<Bitmap>>(Substitute.ForPartsOf<CacheService<Bitmap>>())
                   .RegisterTransientInstance<IAsyncOperationLocker>(Substitute.ForPartsOf<AsyncOperationLocker>())
                   .RegisterTransientInstance<IAsyncZoomLocker>(Substitute.ForPartsOf<AsyncZoomLocker>())
                   .RegisterTransientInstance<IAwaitablePipeline>(Substitute.ForPartsOf<AwaitablePipeline>())
                   .RegisterTransientInstance<IMainFormEventBinder>(Substitute.ForPartsOf<MainFormEventBinder>(aggregator))
                   .RegisterTransientInstance<IMainFormCommand>(Substitute.ForPartsOf<MainFormCommand>());

            var form = Substitute.ForPartsOf<MainFormFake>(
                builder.Resolve<IManualResetEventService>(), controller,
                builder.Resolve<IMainFormEventBinder>(),
                builder.Resolve<IMainFormCommand>()
            );

            builder.RegisterSingletonInstance<IMainFormExposer>(form)
                   .RegisterSingletonInstance<IMainView>(form);

            builder.RegisterTransientInstance(Substitute.ForPartsOf<MainPresenter>(controller,
                builder.Resolve<ICacheService<Bitmap>>(),
                builder.Resolve<INonBlockDialogService>(),
                builder.Resolve<IAwaitablePipeline>(),
                builder.Resolve<IAsyncOperationLocker>(),
                builder.Resolve<IAsyncZoomLocker>())
            );

        }
    }
}
