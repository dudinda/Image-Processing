using System.Drawing;

using ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes;
using ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main;
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
using ImageProcessing.App.UILayer.FormExposers.Rgb;
using ImageProcessing.App.UILayer.FormModel.Factory.MainContainer.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormUndoRedo.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Extensions
{
    internal static class DependencyResolutionExtensions
    {
        public static (IAppController, IEventAggregatorWrapper) BindMocksForMvp(this IComponentProvider builder)
        {
            if(!builder.IsRegistered<IEventAggregatorWrapper>())
            {
                builder.RegisterSingleton<IEventAggregatorWrapper, EventAggregatorWrapper>();
            }

            var controller = builder.Resolve<IAppController>();
            var aggregator = builder.Resolve<IEventAggregatorWrapper>();

            controller.GetType().GetProperty(nameof(controller.Aggregator))
                .SetValue(controller, aggregator);

            return (controller, aggregator);
        }

        public static void BindMocksForMainPresenter(this IComponentProvider builder)
        {
            var (controller, aggregator) = builder.BindMocksForMvp();

            var dialog = Substitute.ForPartsOf<NonBlockDialogServiceWrapper>(
              Substitute.For<IFileDialogService>(), Substitute.For<IStaTaskService>());

            builder
                .RegisterSingletonInstance<INonBlockDialogService>(dialog)
                .RegisterTransientInstance<ICacheService<Bitmap>>(Substitute.ForPartsOf<CacheService<Bitmap>>())
                .RegisterTransientInstance<IAsyncOperationLocker>(Substitute.ForPartsOf<AsyncOperationLocker>())
                .RegisterTransientInstance<IAwaitablePipeline>(Substitute.ForPartsOf<AwaitablePipeline>())
                .RegisterTransientInstance<IMainFormEventBinder>(Substitute.ForPartsOf<MainFormEventBinder>(aggregator))
                .RegisterTransientInstance<IMainFormContainerFactory>(Substitute.ForPartsOf<MainFormContainerFactory>())
                .RegisterTransientInstance<IMainFormUndoRedoFactory>(Substitute.ForPartsOf<MainFormUndoRedoFactory>())
                .RegisterTransientInstance<IMainFormZoomFactory>(Substitute.ForPartsOf<MainFormZoomFactory>())
                .RegisterTransientInstance<IMainFormRotationFactory>(Substitute.ForPartsOf<MainFormRotationFactory>())
                .RegisterTransientInstance<IScalingProvider>(Substitute.For<IScalingProvider>())
                .RegisterTransientInstance<IRotationProvider>(Substitute.For<IRotationProvider>());


            var form = Substitute.ForPartsOf<MainFormWrapper>(controller,
                builder.Resolve<IMainFormEventBinder>(),
                builder.Resolve<IMainFormContainerFactory>(),
                builder.Resolve<IMainFormUndoRedoFactory>(),
                builder.Resolve<IMainFormZoomFactory>(),
                builder.Resolve<IMainFormRotationFactory>());

            builder.RegisterSingletonInstance(form)
                   .RegisterSingletonInstance<IMainView>(form);

            builder.RegisterTransientInstance(Substitute.ForPartsOf<MainPresenterWrapper>(controller,
                builder.Resolve<ICacheService<Bitmap>>(),
                builder.Resolve<INonBlockDialogService>(),
                builder.Resolve<IAwaitablePipeline>(),
                builder.Resolve<IAsyncOperationLocker>(),
                builder.Resolve<IScalingProvider>(),
                builder.Resolve<IRotationProvider>()));

        }

        public static void BindMocksForRgbPresenter(this IComponentProvider builder)
        {
            var (controller, aggregator) = builder.BindMocksForMvp();

            builder.RegisterTransientInstance<IRgbFormEventBinder>(Substitute.ForPartsOf<RgbFormEventBinder>(aggregator));

            var form = Substitute.ForPartsOf<RgbFormWrapper>(controller,
                builder.Resolve<IRgbFormEventBinder>());

            builder.RegisterTransientInstance<IRgbView>(form)
                   .RegisterTransientInstance<IRgbFormExposer>(form);

            builder.RegisterTransientInstance(
               Substitute.For<IRgbServiceProvider>());

            builder.RegisterTransientInstance(
              Substitute.For<RgbPresenterWrapper>(controller,
                  builder.Resolve<IRgbServiceProvider>(),
                  builder.Resolve<IAsyncOperationLocker>()
              ));
        }

        public static void BindMocksForConvolutionPresenter(this IComponentProvider builder)
        {
            var (controller, aggregator) = builder.BindMocksForMvp();

            builder.RegisterTransientInstance<IConvolutionFormEventBinder>(
                Substitute.ForPartsOf<ConvolutionFormEventBinder>(aggregator));

            var form = Substitute.ForPartsOf<ConvolutionFormWrapper>(controller,
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

        public static void BindMocksForDistributionPresenter(this IComponentProvider builder)
        {
            var (controller, aggregator) = builder.BindMocksForMvp();

            builder.RegisterTransientInstance<IDistributionFormEventBinder>(
                Substitute.ForPartsOf<DistributionFormEventBinder>(aggregator));

            var form = Substitute.ForPartsOf<DistributionFormWrapper>(controller,
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
