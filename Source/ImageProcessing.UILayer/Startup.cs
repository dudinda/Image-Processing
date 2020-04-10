using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Core.IoC.Interface;
using ImageProcessing.DomainModel.Factory.Convolution.Implementation;
using ImageProcessing.DomainModel.Factory.Convolution.Interface;
using ImageProcessing.DomainModel.Factory.Distributions.Implementation;
using ImageProcessing.DomainModel.Factory.Distributions.Interface;
using ImageProcessing.DomainModel.Factory.Morphology.Implementation;
using ImageProcessing.DomainModel.Factory.Morphology.Interface;
using ImageProcessing.DomainModel.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.DomainModel.Factory.RgbFilters.Color.Implementation;
using ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface;
using ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Implementation;
using ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.DomainModel.Factory.StructuringElement.Implementation;
using ImageProcessing.EntryPoint.Startup;
using ImageProcessing.Form.Histogram;
using ImageProcessing.Form.Main;
using ImageProcessing.Form.QualityMeasure;
using ImageProcessing.PresentationLayer.Presenters.Main;
using ImageProcessing.PresentationLayer.Views.Convolution;
using ImageProcessing.PresentationLayer.Views.Histogram;
using ImageProcessing.PresentationLayer.Views.Main;
using ImageProcessing.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.ServiceLayer.NonBlockDialog.Implementation;
using ImageProcessing.ServiceLayer.Providers.Implementation.BitmapDistribution;
using ImageProcessing.ServiceLayer.Providers.Implementation.Convolution;
using ImageProcessing.ServiceLayer.Providers.Implementation.Morphology;
using ImageProcessing.ServiceLayer.Providers.Implementation.RgbFilters;
using ImageProcessing.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.ServiceLayer.Providers.Interface.Morphology;
using ImageProcessing.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.ServiceLayer.Services.Bmp.Implementation;
using ImageProcessing.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.ServiceLayer.Services.Cache.Implementation;
using ImageProcessing.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.ServiceLayer.Services.Convolution.Implementation;
using ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.ServiceLayer.Services.Distributions.BitmapLuminance.Implementation;
using ImageProcessing.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.ServiceLayer.Services.Distributions.RandomVariable.Implementation;
using ImageProcessing.ServiceLayer.Services.Distributions.RandomVariable.Interface;
using ImageProcessing.ServiceLayer.Services.EventAggregator.Implementation;
using ImageProcessing.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.ServiceLayer.Services.FileDialog.Implementation;
using ImageProcessing.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.ServiceLayer.Services.LockerService.Operation.Implementation;
using ImageProcessing.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.ServiceLayer.Services.LockerService.Zoom.Implementation;
using ImageProcessing.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.ServiceLayer.Services.Morphology.Implementation;
using ImageProcessing.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.ServiceLayer.Services.Pipeline.AwaitablePipeline.Implementation;
using ImageProcessing.ServiceLayer.Services.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.ServiceLayer.Services.RgbFilters.Implementation;
using ImageProcessing.ServiceLayer.Services.RgbFilters.Interface;
using ImageProcessing.ServiceLayer.Services.StaTask.Implementation;
using ImageProcessing.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.UILayer.Form.Convolution;

namespace ImageProcessing.UILayer
{
    internal class Startup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            builder
                .RegisterSingleton<ApplicationContext>()
                .RegisterSingleton<MainPresenter>()
                .RegisterSingleton<IEventAggregator, EventAggregator>()
                .RegisterSingleton<IAwaitablePipeline, AwaitablePipeline>()
                .RegisterSingleton<ISTATaskService, STATaskService>()
                .RegisterSingleton<IAsyncZoomLocker, AsyncZoomLocker>()
                .RegisterSingleton<ICacheService<Bitmap>, CacheService<Bitmap>>()
                .RegisterSingletonView<IMainView, MainForm>()
                .RegisterTransientView<IHistogramView, HistogramForm>()
                .RegisterTransientView<IConvolutionFilterView, ConvolutionFilterForm>()
                .RegisterTransientView<IQualityMeasureView, QualityMeasureForm>()
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
                .RegisterTransient<IRgbFilterServiceProvider, RgbFilterServiceProvider>();      
        }      
    }
}
