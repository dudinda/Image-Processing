using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Adapters.LightInject;
using ImageProcessing.Core.Adapters.Ninject;
using ImageProcessing.Core.Container;
using ImageProcessing.Core.Controller.Implementation;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Implementation;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Implementation;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.DomainModel.Factory.Convolution.Implementation;
using ImageProcessing.DomainModel.Factory.Convolution.Interface;
using ImageProcessing.DomainModel.Factory.Distributions.Implementation;
using ImageProcessing.DomainModel.Factory.Distributions.Interface;
using ImageProcessing.DomainModel.Factory.Morphology.Implementation;
using ImageProcessing.DomainModel.Factory.Morphology.Interface;
using ImageProcessing.DomainModel.Factory.RgbFilters.Implementation;
using ImageProcessing.DomainModel.Factory.RgbFilters.Interface;
using ImageProcessing.Form.Histogram;
using ImageProcessing.Form.Main;
using ImageProcessing.Form.QualityMeasure;
using ImageProcessing.PresentationLayer.Presenters.Main;
using ImageProcessing.PresentationLayer.Views.Convolution;
using ImageProcessing.PresentationLayer.Views.Histogram;
using ImageProcessing.PresentationLayer.Views.Main;
using ImageProcessing.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.ServiceLayer.Providers.Implementation.BitmapDistribution;
using ImageProcessing.ServiceLayer.Providers.Implementation.Convolution;
using ImageProcessing.ServiceLayer.Providers.Implementation.Morphology;
using ImageProcessing.ServiceLayer.Providers.Implementation.RgbFilter;
using ImageProcessing.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.ServiceLayer.Providers.Interface.Morphology;
using ImageProcessing.ServiceLayer.Providers.Interface.RgbFilter;
using ImageProcessing.ServiceLayer.Services.Bmp.Implementation;
using ImageProcessing.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.ServiceLayer.Services.Convolution.Implementation;
using ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.ServiceLayer.Services.Distributions.BitmapLuminance.Implementation;
using ImageProcessing.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.ServiceLayer.Services.Distributions.RandomVariable.Implementation;
using ImageProcessing.ServiceLayer.Services.Distributions.RandomVariable.Interface;
using ImageProcessing.ServiceLayer.Services.LockerService.Operation.Implementation;
using ImageProcessing.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.ServiceLayer.Services.LockerService.Zoom.Implementation;
using ImageProcessing.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.ServiceLayer.Services.Morphology.Implementation;
using ImageProcessing.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.ServiceLayer.Services.RgbFilter.Implementation;
using ImageProcessing.ServiceLayer.Services.RgbFilter.Interface;
using ImageProcessing.ServiceLayer.Services.StaTask.Implementation;
using ImageProcessing.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.UILayer.Form.Convolution;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.UILayer
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
                .RegisterSingleton<MainPresenter>()
                .RegisterSingleton<IEventAggregator, EventAggregator>()
                .RegisterSingleton<IAwaitablePipeline, AwaitablePipeline>()
                .RegisterSingleton<ISTATaskService, STATaskService>()
                .RegisterSingleton<IAsyncZoomLocker, ZoomAsyncLocker>()
                .RegisterSingletonView<IMainView, MainForm>()
                .RegisterTransientView<IHistogramView, HistogramForm>()
                .RegisterTransientView<IConvolutionFilterView, ConvolutionFilterForm>()
                .RegisterTransientView<IQualityMeasureView, QualityMeasureForm>()
                .RegisterTransient<IConvolutionFilterService, ConvolutionFilterService>()
                .RegisterTransient<IConvolutionFilterFactory, ConvolutionFilterFactory>()
                .RegisterTransient<IMorphologyService, MorphologyService>()
                .RegisterTransient<IMorphologyFactory, MorphologyFactory>()
                .RegisterTransient<IBitmapService, BitmapService>()
                .RegisterTransient<IRandomVariableDistributionService, RandomVariableDistributionService>()
                .RegisterTransient<IBitmapLuminanceDistributionService, BitmapLuminanceDistributionService>()
                .RegisterTransient<IDistributionFactory, DistributionFactory>()
                .RegisterTransient<IRgbFilterService, RgbFilterService>()
                .RegisterTransient<IRgbFilterFactory, RgbFilterFactory>()
                .RegisterScoped<IAsyncOperationLocker, OperationAsyncLocker>()
                .RegisterTransient<IConvolutionServiceProvider, ConvolutionServiceProvider>()
                .RegisterTransient<IMorphologyServiceProvider, MorphologyServiceProvider>()
                .RegisterTransient<IBitmapLuminanceDistributionServiceProvider, BitmapLuminanceDistributionServiceProvider>()
                .RegisterTransient<IRgbFilterServiceProvider, RgbFilterServiceProvider>();
            
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

            _controller.Dispose();
        }
    }
}