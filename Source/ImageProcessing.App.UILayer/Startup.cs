using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Factory.Convolution.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainLayer.Factory.StructuringElement.Implementation;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Implementation;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;
using ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Implementation;
using ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Interface;
using ImageProcessing.App.ServiceLayer.NonBlockDialog.Implementation;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.Morphology;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.RgbFilters;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Morphology;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.Convolution.Implementation;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distributions.RandomVariable.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Distributions.RandomVariable.Interface;
using ImageProcessing.App.ServiceLayer.Services.FileDialog.Implementation;
using ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Histogram.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Implementation;
using ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Interface;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Implementation;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface;
using ImageProcessing.App.ServiceLayer.Services.StaTask.Implementation;
using ImageProcessing.App.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.App.UILayer.Form.Convolution;
using ImageProcessing.App.UILayer.Form.Histogram;
using ImageProcessing.App.UILayer.Form.Main;
using ImageProcessing.App.UILayer.Form.QualityMeasure;
using ImageProcessing.App.UILayer.Form.Rgb;
using ImageProcessing.App.UILayer.FormCommands.Main.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.UILayer
{
    internal class Startup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            builder
                .RegisterSingleton<IAwaitablePipeline, AwaitablePipeline>()
                .RegisterSingleton<IStaTaskService, StaTaskService>()
                .RegisterSingleton<IAsyncZoomLocker, AsyncZoomLocker>()
                .RegisterSingleton<ICacheService<Bitmap>, CacheService<Bitmap>>()
                .RegisterSingletonView<IMainView, MainForm>()
                .RegisterTransientView<IHistogramView, HistogramForm>()
                .RegisterTransientView<IConvolutionView, ConvolutionFilterForm>()
                .RegisterTransientView<IRgbView, RgbForm>()
                .RegisterSingletonView<IQualityMeasureView, QualityMeasureForm>()
                .RegisterTransient<IConvolutionFilterService, ConvolutionFilterService>()
                .RegisterTransient<IConvolutionFilterFactory, ConvolutionFilterFactory>()
                .RegisterTransient<IMorphologyService, MorphologyService>()
                .RegisterTransient<IMorphologyFactory, MorphologyFactory>()
                .RegisterTransient<IStructuringElementFactory, StructuringElementFactory>()
                .RegisterTransient<IBitmapService, BitmapService>()
                .RegisterTransient<IRandomVariableDistributionService, RandomVariableDistributionService>()
                .RegisterTransient<IBitmapLuminanceDistributionService, BitmapLuminanceDistributionService>()
                .RegisterTransient<IDistributionFactory, DistributionFactory>()
                .RegisterTransient<IFileDialogService, FileDialogService>()
                .RegisterScoped<INonBlockDialogService, NonBlockDialogService>()
                .RegisterTransient<IRgbFilterService, RgbFilterService>()
                .RegisterTransient<IRgbFilterFactory, RgbFilterFactory>()
                .RegisterScoped<IColorFactory, ColorFactory>()
                .RegisterScoped<IAsyncOperationLocker, AsyncOperationLocker>()
                .RegisterTransient<IConvolutionServiceProvider, ConvolutionServiceProvider>()
                .RegisterTransient<IMorphologyServiceProvider, MorphologyServiceProvider>()
                .RegisterTransient<IBitmapLuminanceDistributionServiceProvider, BitmapLuminanceDistributionServiceProvider>()
                .RegisterTransient<IRgbFilterServiceProvider, RgbFilterServiceProvider>()
                .RegisterScoped<IChartSeriesBuilder, ChartSeriesBuilder>()
                .RegisterTransient<IQualityMeasureService, QualityMeasureService>()
                .RegisterTransient<IHistogramService, HistogramService>()
                .RegisterTransient<IMainPresenterLockersFacade, MainPresenterLockersFacade>()
                .RegisterTransient<IRgbFormEventBinder, RgbFormEventBinder>()
                .RegisterTransient<IConvolutionFormEventBinder, ConvolutionFormEventBinder>()
                .RegisterTransient<IMainFormEventBinder, MainFormEventBinder>()
                .RegisterTransient<IMainFormCommand, MainFormCommand>()
                .RegisterTransient<IRgbFormCommand, RgbFormCommand>();      
        }      
    }
}
