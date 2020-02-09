using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Core.Adapters.LightInject;
using ImageProcessing.Core.Controller.Implementation;
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

namespace ImageProcessing
{
    internal static class Program
    {
        internal static readonly ApplicationContext _context = new ApplicationContext();

        [STAThread]
        internal static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var controller = new AppController(new LightInjectAdapter())
                    .RegisterView<IMainView, MainForm>()
                    .RegisterView<IHistogramView, HistogramForm>()
                    .RegisterView<IQualityMeasureView, QualityMeasureForm>()
                    .RegisterService<IBaseFactory, BaseFactory>()
                    .RegisterService<IConvolutionFilterService, ConvolutionFilterService>()
                    .RegisterService<IRandomVariableDistributionService, RandomVariableDistributionService>()
                    .RegisterService<IBitmapLuminanceDistributionService, BitmapLuminanceDistributionService>()
                    .RegisterService<IRGBFilterService, RGBFilterService>()
                    .EnableAnnotatedConstructorInjection()
                    .RegisterNamedSingletonService<IAsyncLocker, ZoomAsyncLocker>("ZoomLocker")
                    .RegisterNamedSingletonService<IAsyncLocker, OperationAsyncLocker>("OperationLocker")
                    .RegisterSingletonService<IEventAggregator, EventAggregator>()
                    .RegisterSingletonService<IAwaitablePipeline<Bitmap>, AwaitablePipeline<Bitmap>>()
                    .RegisterSingletonService<ISTATaskService, STATaskService>()
                    .RegisterInstance(_context);

                controller.Run<MainPresenter>();
            }
            catch
            {
                _context.Dispose();
            }
        }
    }
}
