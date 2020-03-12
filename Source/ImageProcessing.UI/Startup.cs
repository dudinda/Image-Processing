using System;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Adapters.LightInject;
using ImageProcessing.Core.Container;
using ImageProcessing.Core.Controller.Implementation;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Implementation;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Locker.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Implementation;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Core.Service.STATask;
using ImageProcessing.Factory.Base;
using ImageProcessing.Form.Histogram;
using ImageProcessing.Form.Main;
using ImageProcessing.Form.QualityMeasure;
using ImageProcessing.Presentation.Presenters.Main;
using ImageProcessing.Presentation.Views.Convolution;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Presentation.Views.QualityMeasure;
using ImageProcessing.Services.ConvolutionFilterServices.Implementation;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.DistributionServices.Distribution.Interface;
using ImageProcessing.Services.DistributionServices.RandomVariableDistribution;
using ImageProcessing.Services.LockerService.Operation;
using ImageProcessing.Services.LockerService.Zoom;
using ImageProcessing.Services.RGBFilterService.Implementation;
using ImageProcessing.Services.RGBFilterService.Interface;
using ImageProcessing.Services.STATask;
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

            _controller = new AppController(GetContainerAdapter(container));

            _controller.IoC
                .RegisterSingleton<ApplicationContext>()
                .Register<IMainView, MainForm>()
                .RegisterView<IHistogramView, HistogramForm>()
                .RegisterView<IConvolutionFilterView, ConvolutionFilterForm>()
                .RegisterView<IQualityMeasureView, QualityMeasureForm>()
                .Register<IBaseFactory, BaseFactory>()
                .Register<IConvolutionFilterService, ConvolutionFilterService>()
                .Register<IRandomVariableDistributionService, RandomVariableDistributionService>()
                .Register<IBitmapLuminanceDistributionService, BitmapLuminanceDistributionService>()
                .Register<IRGBFilterService, RGBFilterService>()
                .EnableAnnotatedConstructorInjection()
                .RegisterNamedSingleton<IAsyncLocker, ZoomAsyncLocker>("ZoomLocker")
                .RegisterNamedSingleton<IAsyncLocker, OperationAsyncLocker>("OperationLocker")
                .RegisterSingleton<IEventAggregator, EventAggregator>()
                .RegisterSingleton<IAwaitablePipeline, AwaitablePipeline>()
                .RegisterSingleton<ISTATaskService, STATaskService>();
                

            IContainer GetContainerAdapter()
            {
                switch (container)
                {
                    case Container.LightInject:
                        return new LightInjectAdapter();

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
