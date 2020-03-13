using System;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Adapters.LightInject;
using ImageProcessing.Core.Adapters.Ninject;
using ImageProcessing.Core.Container;
using ImageProcessing.Core.Controller.Implementation;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Implementation;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Factory.Morphology;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Implementation;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Core.ServiceLayer.Providers.Convolution;
using ImageProcessing.Core.ServiceLayer.Providers.Morphology;
using ImageProcessing.Core.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.Core.ServiceLayer.Services.Morphology;
using ImageProcessing.Core.ServiceLayer.Services.STATask;
using ImageProcessing.DomainModel.Factory.Filters.Implementation.Morphology;
using ImageProcessing.Factory.Base;
using ImageProcessing.Factory.Filters.Convolution;
using ImageProcessing.Form.Histogram;
using ImageProcessing.Form.Main;
using ImageProcessing.Form.QualityMeasure;
using ImageProcessing.Presentation.Presenters.Main;
using ImageProcessing.Presentation.Views.Convolution;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Presentation.Views.QualityMeasure;
using ImageProcessing.ServiceLayer.Providers.Morphology;
using ImageProcessing.ServiceLayer.Service.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Implementation;
using ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.ServiceLayer.Services.DistributionServices.BitmapLuminanceDistribution;
using ImageProcessing.ServiceLayer.Services.DistributionServices.Distribution.Interface;
using ImageProcessing.ServiceLayer.Services.DistributionServices.RandomVariableDistribution;
using ImageProcessing.ServiceLayer.Services.LockerService.Operation;
using ImageProcessing.ServiceLayer.Services.LockerService.Zoom;
using ImageProcessing.ServiceLayer.Services.Morphology;
using ImageProcessing.ServiceLayer.Services.RGBFilterService.Implementation;
using ImageProcessing.ServiceLayer.Services.RGBFilterService.Interface;
using ImageProcessing.ServiceLayer.Services.STATask;
using ImageProcessing.Services.Providers;
using ImageProcessing.UI.Form.Convolution;

namespace ImageProcessing.UI
{
    internal static class Startup 
    {
        private static IAppController _controller;

        internal static void Build(Container container)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _controller = new AppController(GetContainerAdapter());

            _controller.IoC
                .RegisterSingleton<ApplicationContext>()
                .RegisterSingleton<IEventAggregator, EventAggregator>()
                .RegisterSingleton<IAwaitablePipeline, AwaitablePipeline>()
                .RegisterSingleton<ISTATaskService, STATaskService>()
                .Register<IMainView, MainForm>()
                .RegisterView<IHistogramView, HistogramForm>()
                .RegisterView<IConvolutionFilterView, ConvolutionFilterForm>()
                .RegisterView<IQualityMeasureView, QualityMeasureForm>()
                .Register<IBaseFactory, BaseFactory>()
                .Register<IConvolutionFilterService, ConvolutionFilterService>()
                .Register<IConvolutionFilterFactory, ConvolutionFilterFactory>()
                .Register<IMorphologyService, MorphologyService>()
                .Register<IMorphologyFactory, MorphologyFactory>()
                .Register<IRandomVariableDistributionService, RandomVariableDistributionService>()
                .Register<IBitmapLuminanceDistributionService, BitmapLuminanceDistributionService>()
                .Register<IRGBFilterService, RGBFilterService>()
                .RegisterSingleton<IAsyncZoomLocker, ZoomAsyncLocker>()
                .Register<IAsyncOperationLocker, OperationAsyncLocker>()
                .Register<IConvolutionFilterServiceProvider, ConvolutionFilterServiceProvider>()
                .Register<IMorphologyServiceProvider, MorphologyServiceProvider>();

            IContainer GetContainerAdapter()
            {
                switch (container)
                {
                    case Container.LightInject:
                        return new LightInjectAdapter();
                    case Container.Ninject:
                        return new NinjectAdapter();

                    default: throw new NotImplementedException(nameof(container));
                }
            };
        }

        internal static void Run()
        {
            if (_controller is null)
            {
                throw new InvalidOperationException("The application is not built.");
            }

            _controller.Run<MainPresenter>();
        }

        internal static void Exit()
        {
            if (_controller is null)
            {
                throw new InvalidOperationException("The application is not built.");
            }

            _controller.Exit<ApplicationContext>();
        }
    }
}
