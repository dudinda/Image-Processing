using System.Drawing;

using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes;
using ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Presenters;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Distribution;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.FormCommands.Main.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.App.UILayer.FormExposers.Distribution;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Extensions
{
    internal static class DependencyResolutionExtensions
    {
        public static (IAppController, IEventAggregatorWrapper, IAutoResetEventService) BindMocksForMvp(this IDependencyResolution builder)
        {
            if(!builder.IsRegistered<IEventAggregatorWrapper>())
            {
                builder.RegisterSingleton<IEventAggregatorWrapper, EventAggregatorWrapper>();
            }

            if(!builder.IsRegistered<IAutoResetEventService>())
            {
                builder.RegisterSingleton<IAutoResetEventService, AutoResetEventService>();
            }
  
            var controller = builder.Resolve<IAppController>();
            var aggregator = builder.Resolve<IEventAggregatorWrapper>();
            var synchronizer = builder.Resolve<IAutoResetEventService>();

            controller.GetType().GetProperty(nameof(controller.Aggregator))
                .SetValue(controller, aggregator);

            return (controller, aggregator, synchronizer);
        }

        public static void BindMocksForMainPresenter(this IDependencyResolution builder)
        {
            var (controller, aggregator, synchronizer) = builder.BindMocksForMvp();

            var dialog = Substitute.ForPartsOf<NonBlockDialogServiceWrapper>(synchronizer,
              Substitute.For<IFileDialogService>(), Substitute.For<IStaTaskService>());

            builder.RegisterSingletonInstance<INonBlockDialogService>(dialog)
                   .RegisterTransientInstance<ICacheService<Bitmap>>(Substitute.ForPartsOf<CacheService<Bitmap>>())
                   .RegisterTransientInstance<IAsyncOperationLocker>(Substitute.ForPartsOf<AsyncOperationLocker>())
                   .RegisterTransientInstance<IAsyncZoomLocker>(Substitute.ForPartsOf<AsyncZoomLocker>())
                   .RegisterTransientInstance<IAwaitablePipeline>(Substitute.ForPartsOf<AwaitablePipeline>())
                   .RegisterTransientInstance<IMainFormEventBinder>(Substitute.ForPartsOf<MainFormEventBinder>(aggregator))
                   .RegisterTransientInstance<IMainFormCommand>(Substitute.ForPartsOf<MainFormCommand>());

            var form = Substitute.ForPartsOf<MainFormWrapper>(synchronizer, controller,
                builder.Resolve<IMainFormEventBinder>(),
                builder.Resolve<IMainFormCommand>());

            builder.RegisterSingletonInstance<IMainFormExposer>(form)
                   .RegisterSingletonInstance<IMainView>(form);

            builder.RegisterTransientInstance(Substitute.ForPartsOf<MainPresenterWrapper>(controller,
                builder.Resolve<ICacheService<Bitmap>>(),
                builder.Resolve<INonBlockDialogService>(),
                builder.Resolve<IAwaitablePipeline>(),
                builder.Resolve<IAsyncOperationLocker>(),
                builder.Resolve<IAsyncZoomLocker>()));

        }

        public static void BindMocksForRgbPresenter(this IDependencyResolution builder)
        {
            var (controller, aggregator, synchronizer) = builder.BindMocksForMvp();

            builder.RegisterTransientInstance<IRgbFormEventBinder>(Substitute.ForPartsOf<RgbFormEventBinder>(aggregator))
                   .RegisterTransientInstance<IRgbFormCommand>(Substitute.ForPartsOf<RgbFormCommand>());

            var form = Substitute.ForPartsOf<RgbFormWrapper>(synchronizer, controller,
                builder.Resolve<IRgbFormEventBinder>(),
                builder.Resolve<IRgbFormCommand>());

            builder.RegisterTransientInstance<IRgbView>(form)
                   .RegisterTransientInstance<IRgbFormExposer>(form);

            builder.RegisterTransientInstance(
               Substitute.For<IRgbFilterServiceProvider>());

            builder.RegisterTransientInstance(
              Substitute.For<RgbPresenterWrapper>(controller,
                  builder.Resolve<IRgbFilterServiceProvider>(),
                  builder.Resolve<IAsyncOperationLocker>()
              ));
        }

        public static void BindMocksForConvolutionPresenter(this IDependencyResolution builder)
        {
            var (controller, aggregator, synchronizer) = builder.BindMocksForMvp();

            builder.RegisterTransientInstance<IConvolutionFormEventBinder>(
                Substitute.ForPartsOf<ConvolutionFormEventBinder>(aggregator));

            var form = Substitute.ForPartsOf<ConvolutionFormWrapper>(synchronizer, controller,
                    builder.Resolve<IConvolutionFormEventBinder>());

            builder.RegisterTransientInstance<IConvolutionView>(form)
                   .RegisterTransientInstance<IConvolutionFormExposer>(form);

            builder.RegisterTransientInstance<IConvolutionServiceProvider>(
                Substitute.For<IConvolutionServiceProvider>());

            builder.RegisterTransientInstance(
                Substitute.For<ConvolutionPresenterWrapper>(controller,
                    builder.Resolve<IConvolutionServiceProvider>(),
                    builder.Resolve<IAsyncOperationLocker>()
                ));
        }

        public static void BindMocksForDistributionPresenter(this IDependencyResolution builder)
        {
            var (controller, aggregator, synchronizer) = builder.BindMocksForMvp();

            builder.RegisterTransientInstance<IDistributionFormEventBinder>(
                Substitute.ForPartsOf<DistributionFormEventBinder>(aggregator));

            var form = Substitute.ForPartsOf<DistributionFormWrapper>(synchronizer, controller,
                    builder.Resolve<IDistributionFormEventBinder>());

            builder.RegisterTransientInstance<IDistributionView>(form)
                   .RegisterTransientInstance<IDistributionFormExposer>(form);

            builder.RegisterTransientInstance<IBitmapLuminanceServiceProvider>(
                Substitute.For<IBitmapLuminanceServiceProvider>());

            builder.RegisterTransientInstance(
                Substitute.For<DistributionPresenterWrapper>(controller,
                    builder.Resolve<IAsyncOperationLocker>(),
                    builder.Resolve<IBitmapLuminanceServiceProvider>()
                ));
        }
    }
}
